﻿using Avans.TI.BLE;
using System;
using System.Threading;

namespace IPR_LIB
{
    public class BikeHandler
    {
        public bool onCool;
        BLE bleBike;
        BLE bleHeart;
        private byte voltage;
        public double CurrentResistance;
        public double Rpm { get; private set; }
        public bool updated = false;
        public int BPM { get; private set; }

        public bool StartConnection()
        {
            try
            {
                bleBike = new BLE();
                bleHeart = new BLE();
                CurrentResistance = 0;
                Thread.Sleep(1000); // We need some time to list available devices
                return true;
            }
            catch { return false; }
        }
        public async void setUpBikeConection(string bike)
        {
            //string should be like "Tacx Flux 00438"
            int errorCode = 0;
            // Connecting
            errorCode = errorCode = await bleBike.OpenDevice("Tacx Flux " + bike);

            var services = bleBike.GetServices;
            foreach (var service in services)
            {
                Console.WriteLine($"Service: {service}");
            }
            // Set service
            errorCode = await bleBike.SetService("6e40fec1-b5a3-f393-e0a9-e50e24dcca9e");

            // Subscribe
            bleBike.SubscriptionValueChanged += BleBike_SubscriptionValueChanged;
            errorCode = await bleBike.SubscribeToCharacteristic("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e");

            // Heart rate
            errorCode = await bleHeart.OpenDevice("Decathlon Dual HR");

            await bleHeart.SetService("HeartRate");

            bleHeart.SubscriptionValueChanged += BleBike_SubscriptionValueChanged;
            await bleHeart.SubscribeToCharacteristic("HeartRateMeasurement");
        }

        private void BleBike_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        {
            HandlePayload(e.Data);
        }

        private void HandlePayload(byte[] dat)
        {
            if (dat.Length > 4)
            {
                String stringData = BitConverter.ToString(dat);
                if (stringData.Substring(0, 2).Equals("16"))
                {
                    BPM = Convert.ToInt32(stringData.Substring(3, 2), 16);
                }
                else
                    switch (dat[4])
                    {
                        case 0x19:
                            voltage = (byte)((((byte)dat[8] << 8) | ((byte)dat[7])));
                            Rpm = dat[6];
                            break;
                    }
                updated = true;
            }
        }

        public void ResistanceOnHR()
        {
            while (true)
            {
                if (onCool) break;
                else if (BPM < 130 && CurrentResistance < 100)
                {
                    CurrentResistance += 0.5;
                    setResistance(CurrentResistance);
                }
                else if (BPM > 130 && CurrentResistance > 0)
                {
                    CurrentResistance -= 0.5;
                    setResistance(CurrentResistance);
                }
                Thread.Sleep(5000);
            }
            setResistance(0);
        }

        public void setResistance(double percentage)
        {
            CurrentResistance = percentage;

            var crc32 = new Crc32.Crc32Algorithm(0xedb88320u,
                                  0xffffffffu);
            byte[] output = new byte[13];
            output[0] = 0x4A; // Sync bit;
            output[1] = 0x09; // Message Length
            output[2] = 0x4E; // Message type
            output[3] = 0x05; // Message type
            output[4] = 0x30; // Data Type
            output[11] = (byte)(percentage * 2);
            output[12] = (byte)BitConverter.ToInt32(crc32.ComputeHash(output), 0);
            bleBike.WriteCharacteristic("6e40fec3-b5a3-f393-e0a9-e50e24dcca9e", output);
        }
        public (double, int, int) Update()
        {
            updated = false;
            return (Rpm, BPM, voltage);
        }

    }
}
