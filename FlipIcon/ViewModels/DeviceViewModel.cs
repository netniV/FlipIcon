using FlipIcon.Devices;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlipIcon.ViewModels
{
    public enum FlipStatus
    {
        Unknown,
        Normal,
        MakingNomral,
        Flipped,
        MakingFlipped
    }

    public class DeviceViewModel : MenuItemViewModel
    {
        public DeviceViewModel(MenuItemViewModel parentViewModel) : base(parentViewModel)
        {
            IsCheckable = true;
            IsChecked = false;
        }

        public async Task Flip()
        {
            await Task.Run(() =>
            {
                if (mEntry != null)
                {
                    mEntry.FlipVScroll = !mEntry.FlipVScroll;
                    IsChecked = mEntry.FlipVScroll;
                }
            });
        }

        private USBDeviceInfo mEntry;
        public USBDeviceInfo Entry
        {
            get { return mEntry; }
            set
            {
                if (value != mEntry)
                {
                    OnPropertyChanging("Entry");
                    mEntry = value;
                    GroupName = null;
                    if (value != null)
                    {
                        IsEnabled = mEntry.Enabled;
                        FlipStatus = mEntry.FlipVScroll ? FlipStatus.Flipped : FlipStatus.Normal;
                        IsChecked = mEntry.FlipVScroll;

                        Regex nameMatch = new Regex("(.*?)\\((.*?)\\)");
                        var result = nameMatch.Match(value.Description);
                        if (result.Success)
                        {
                            Name = result.Groups[result.Groups.Count - 1].Value;
                            GroupName = result.Groups.Count < 3 ? null : result.Groups[1].Value;
                        }
                        else
                            Name = value.Description;
                    }
                    else
                    {
                        Name = "Unknown";
                        FlipStatus = FlipStatus.Unknown;
                        IsChecked = false;
                        IsEnabled = false;
                    }

                    OnPropertyChanged("Entry");
                }
            }
        }

        public string FullName => Entry?.Description;

        public String Id => (Entry?.DeviceID);
        public bool HorizontalScroll => (Entry?.FlipVScroll).GetValueOrDefault();

        public bool IsChanging => !IsEnabled;

        public string Abbreviation
        {
            get
            {
                string fullName = FullName;
                StringBuilder abbr = new StringBuilder();
                if (!string.IsNullOrWhiteSpace(fullName))
                    for (int index = 0; index < fullName.Length; index++)
                    {
                        char currentChar = fullName[index];
                        if (Char.IsUpper(currentChar))
                        {
                            if (index == 0 || !Char.IsLetterOrDigit(fullName[index - 1]))
                            {
                                abbr.Append(currentChar);
                            }
                        }
                    }

                return (abbr.Length == 0) ? "??" : abbr.ToString().ToLower();
            }
        }


        private FlipStatus mFlipStatus = FlipStatus.Unknown;
        public FlipStatus FlipStatus
        {
            get { return mFlipStatus; }
            set
            {
                if (value != mFlipStatus)
                {
                    OnPropertyChanging(nameof(FlipStatus));
                    mFlipStatus = value;
                    OnPropertyChanged(nameof(FlipStatus));
                }
            }
        }

        public override bool IsEnabled
        {
            get
            {
                return base.IsEnabled;
            }

            set
            {
                base.IsEnabled = value;
            }
        }

        public override bool IsChecked
        {
            get
            {
                return base.IsChecked;
            }

            set
            {
                if (value != base.IsChecked)
                {
                    mEntry.FlipVScroll = value;
                    base.IsChecked = value;
                }
            }
        }


        private string mGroupName;
        public string GroupName
        {
            get { return mGroupName; }
            private set
            {
                if (value != mGroupName)
                {
                    OnPropertyChanging("GroupName");
                    mGroupName = value;
                    OnPropertyChanged("GroupName");
                }
            }
        }

        private string mName;
        public string Name
        {
            get { return mName; }
            private set
            {
                if (value != mName)
                {
                    OnPropertyChanging("FullName");
                    OnPropertyChanging("Name");
                    mName = value;
                    Header = value;
                    OnPropertyChanged("Name");
                    OnPropertyChanged("FullName");
                }
            }
        }

        public event EventHandler<ErrorEventArgs> Error;

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Connection() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}