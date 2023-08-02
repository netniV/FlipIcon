using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipIcon.Devices
{
    public class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
            this.DeviceID = deviceID;
            this.PnpDeviceID = pnpDeviceID;
            this.Description = description;
            this.Enabled = true;
        }
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }

        public bool Enabled { get; set; }

        public string ParamKey
        {
            get
            {
                return $@"SYSTEM\CurrentControlSet\Enum\{PnpDeviceID}\Device Parameters";
            }
        }

        private bool? mFlipHScroll = null;
        public bool FlipHScroll
        {
            get
            {
                if (mFlipHScroll == null)
                {
                    mFlipHScroll = ReadRegValue(isHorizontal: true);
                }

                return mFlipHScroll.GetValueOrDefault();
            }

            set
            {
                if (value != mFlipHScroll.GetValueOrDefault())
                {
                    if (value != ReadRegValue(isHorizontal: true))
                    {
                        // Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\HID\VID_062A&PID_5918&MI_01&Col01\7&145be25b&0&0000\Device Parameters
                        using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default).OpenSubKey(ParamKey))
                        {
                            if (rk != null)
                            {
                                rk.SetValue("FlipFlopHScroll", value ? 1 : 0);
                            }
                        }

                        value = ReadRegValue(isHorizontal: true);
                    }

                    mFlipHScroll = value;

                    if (USBDevices.UpdateSystem)
                    {
                        Enable(false);
                        Enable(true);
                    }
                }
            }
        }

        private bool? mFlipVScroll = null;
        public bool FlipVScroll
        {
            get
            {
                if (mFlipVScroll == null)
                {
                    mFlipVScroll = ReadRegValue(isHorizontal: false);
                }

                return mFlipVScroll.GetValueOrDefault();
            }

            set
            {
                if (value != mFlipVScroll.GetValueOrDefault())
                {
                    if (value != ReadRegValue(isHorizontal: false))
                    {
                        // Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\HID\VID_062A&PID_5918&MI_01&Col01\7&145be25b&0&0000\Device Parameters
                        using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default).OpenSubKey(ParamKey, true))
                        {
                            if (rk != null)
                            {
                                rk.SetValue("FlipFlopWheel", value ? 1 : 0);
                            }
                        }

                        value = ReadRegValue(isHorizontal: false);
                    }

                    mFlipVScroll = value;

                    if (USBDevices.UpdateSystem)
                    {
                        Enable(false);
                        Enable(true);
                    }
                }
            }
        }

        private bool ReadRegValue(bool isHorizontal)
        {
            // Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\HID\VID_062A&PID_5918&MI_01&Col01\7&145be25b&0&0000\Device Parameters
            using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default).OpenSubKey(ParamKey))
            {
                if (rk != null)
                {
                    object rv = rk.GetValue(isHorizontal ? "FlipFlopHScroll" : "FlipFlopWheel", 0);
                    int? ri = rv as int?;
                    return ri.GetValueOrDefault() != 0;
                }

                return false;
            }
        }

        public void Enable(bool enable)
        {
            // every type of device has a hard-coded GUID, this is the one for mice
            Guid mouseGuid = new Guid("{4d36e96f-e325-11ce-bfc1-08002be10318}");

            DeviceHelper.SetDeviceEnabled(mouseGuid, DeviceID, enable);
        }
    }
}
