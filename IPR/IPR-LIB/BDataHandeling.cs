using Avans.TI.BLE;
using System;
using System.Collections.Generic;
using System.Threading;

namespace IPR_LIB
{
    public class BDataHandler : Updatable
    {
        public List<string> Devices = new List<string>();
        BLE bleBike;
        BLE bleHeart;
        private int speed;
        private int distance;
        private int acumilatedPower;
        private int currentPower;
        public bool updated = false;

        public bool StartConnection()
        {
            bleBike = new BLE();
            bleHeart = new BLE();
            Thread.Sleep(1000); // We need some time to list available devices

            // List available devices
            List<String> Devices = bleBike.ListDevices();
            Console.WriteLine("Devices found: ");
            foreach (var name in Devices)
            {
                Console.WriteLine($"Device: {name}");
            }
            return true;
        }

        public async void setUpBikeConection(string bike)
        {
            //string should be like "Tacx Flux 00438"
            int errorCode = 0;
            // Connecting
            errorCode = errorCode = await bleBike.OpenDevice("Tacx Flux 00438");
            // __TODO__ Error check

            var services = bleBike.GetServices;
            foreach (var service in services)
            {
                Console.WriteLine($"Service: {service}");
            }
            // Set service
            errorCode = await bleBike.SetService("6e40fec1-b5a3-f393-e0a9-e50e24dcca9e");
            // __TODO__ error check

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
            switch (dat[4])
            {
                case 0x10:
                    speed = dat[9] + dat[8];
                    distance = dat[7];
                    break;
                case 0x14: break;
                case 0x19:
                    acumilatedPower += dat[8] + dat[7];
                    currentPower = dat[10] + dat[9];
                    break;
            }
            updated = true;
        }
        public void setResistance(int percentage)
        {

            var crc32 = new Crc32.Crc32Algorithm(0xedb88320u,
                                  0xffffffffu);
            byte[] output = new byte[13];
            output[0] = 0x4A; // Sync bit;
            output[1] = 0x09; // Message Length
            output[2] = 0x4E; // Message type
            output[3] = 0x05; // Message type
            output[4] = 0x30; // Data Type
            output[11] = (byte)percentage;
            output[12] = (byte)BitConverter.ToInt32(crc32.ComputeHash(output), 0);

            bleBike.WriteCharacteristic("6e40fec3-b5a3-f393-e0a9-e50e24dcca9e", output);
        }

        public (int, int, int, int) Update()
        {
            updated = false;
            return (speed, distance, acumilatedPower, currentPower);
        }
    }
}
