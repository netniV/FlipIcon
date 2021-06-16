using System;
using System.Collections.Generic;
using System.Management; // need to add System.Management to your project references.
using System.Text;

namespace FlipIcon.Devices
{
    class USBDevices : List<USBDeviceInfo>
    {
        public USBDevices() : this(USBDevices.Get())
        {

        }

        public USBDevices(int capacity) : base(capacity)
        {

        }

        public USBDevices(IEnumerable<USBDeviceInfo> collection) : base(collection)
        {

        }

        private USBDevices(bool noInit) : base()
        {

        }

        public static USBDevices Get()
        {
            SettingsManager<List<USBDeviceInfo>> deviceSettings = new SettingsManager<List<USBDeviceInfo>>("devices.json");
            USBDevices devices = new USBDevices(true);
            StringBuilder s = new StringBuilder();

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
            {
                using (ManagementObjectCollection collection = searcher.Get())
                {
                    foreach (ManagementBaseObject device in collection)
                    {
                        string pnpClass = device.GetPropertyValue("PNPClass") as string;
                        if (String.Equals("Mouse", pnpClass, StringComparison.InvariantCultureIgnoreCase))
                        {
                            foreach (var v in device.Properties)
                            {
                                _ = s.AppendLine($"{v.Name,-30} = {v.Value ?? "<null>"}");
                            }

                            devices.Add(new USBDeviceInfo(
                            (string)device.GetPropertyValue("DeviceID"),
                            (string)device.GetPropertyValue("PNPDeviceID"),
                            (string)device.GetPropertyValue("Description")
                            ));

                            _ = s.AppendLine();
                            _ = s.AppendLine();
                        }
                    }
                }
            }

            USBDevices.UpdateSystem = false;
            List<USBDeviceInfo> oldDevices = deviceSettings.LoadSettings();
            USBDevices.UpdateSystem = true;

            if (oldDevices != null)
                foreach (var oldDevice in oldDevices)
                {
                    bool wasFound = false;
                    foreach (var newDevice in devices)
                    {
                        if (oldDevice.DeviceID.Equals(newDevice.DeviceID))
                        {
                            wasFound = true;
                            break;
                        }
                    }

                    if (!wasFound)
                    {
                        oldDevice.Enabled = false;
                        devices.Add(oldDevice);
                    }
                }

            deviceSettings.SaveSettings(devices);
            return devices;
        }

        public static bool Locked { get; set; } = true;
        public static bool UpdateSystem { get; private set; }
    }
}
