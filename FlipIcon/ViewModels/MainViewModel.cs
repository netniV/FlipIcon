using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using FlipIcon.Async;
using FlipIcon.Handler;
using FlipIcon.Windows;
using FlipIcon.Devices;

namespace FlipIcon.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Constructors

        public MainViewModel() : base()
        {
            mIconSource = IconHandler.DisconnectedSource;

            Dispatcher = Dispatcher.CurrentDispatcher;

            CreateMenuEntries();
            UpdateTrayIcon();
        }

        private void CreateMenuEntries()
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new Action(() => { CreateMenuEntries(); }), DispatcherPriority.Normal, new object[] { });
            } else
            {
                Entries = new ObservableCollection<USBDeviceInfo>(USBDevices.Get());
            }
        }

        #endregion Public Constructors

        #region Private Fields

        private RelayCommand mAboutMenuCommand;
        private bool mAboutMenuItemEnabled = true;
        private ConnectionStatusBalloon mBalloon;
        private BalloonTipEventArgs mBalloonTip;
        private RelayCommand mFlipCommand;
        private List<DeviceViewModel> mConnections = null;
        private ObservableCollection<USBDeviceInfo> mEntries;
        private RelayCommand mExitApplicationCommand;
        private Visibility mExtraMenuItemsVisibility = Visibility.Visible;
        private ConnectionsGroupsViewModel mGroupedMenuItems;
        private Visibility mGroupingSeparatorVisibility = Visibility.Visible;
        private ImageSource mIconSource;
        private bool mIsWindows8Mode = false;
        private PopupActivationMode mMenuActivationMode = GetMenuActivationModeFromWindows8Mode(false);
        private DeviceViewModel mSelectedConnection = null;
        private RelayCommand mSetExtraMenuItemsVisiblityCommand;
        private RelayCommand mShowAppBarCommand;
        private RelayCommand mStartupCommand;
        private ConnectionsGroupViewModel mUngroupedMenuItems;

        #endregion Private Fields

        #region Public Properties

        public ICommand AboutMenuCommand
        {
            get
            {
                if (mAboutMenuCommand == null)
                    mAboutMenuCommand = new RelayCommand(doAboutMenuCommand, canAboutMenuCommand);

                return mAboutMenuCommand;
            }
        }

        public bool AboutMenuItemEnabled
        {
            get
            {
                return mAboutMenuItemEnabled;
            }
            set
            {
                if (value != mAboutMenuItemEnabled)
                {
                    OnPropertyChanging("AboutMenuItemEnabled");
                    mAboutMenuItemEnabled = value;
                    OnPropertyChanged("AboutMenuItemEnabled");
                }
            }
        }

        public ConnectionStatusBalloon Balloon
        {
            get
            {
                return mBalloon;
            }
            set
            {
                if (value != mBalloon)
                {
                    OnPropertyChanging("Balloon");
                    mBalloon = value;
                    OnPropertyChanged("Balloon");
                }
            }
        }

        public BalloonTipEventArgs BalloonTip
        {
            get
            {
                return mBalloonTip;
            }
            set
            {
                if (value != mBalloonTip)
                {
                    OnPropertyChanging("BalloonTip");
                    mBalloonTip = value;
                    OnPropertyChanged("BalloonTip");
                }
            }
        }

        public ICommand FlipCommand
        {
            get
            {
                if (mFlipCommand == null)
                    mFlipCommand = new RelayCommand(doFlipCommand, canFlipCommand);

                return mFlipCommand;
            }
        }

        public List<DeviceViewModel> Connections
        {
            get
            {
                return mConnections;
            }
            set
            {
                if (value != mConnections)
                {
                    OnPropertyChanging(nameof(Connections));
                    mConnections = value;
                    OnPropertyChanged(nameof(Connections));
                }
            }
        }

        public string ConnectionStatus
        {
            get
            {
                StringBuilder sbStatus = new StringBuilder();
                return sbStatus.ToString();
            }
        }

        public ObservableCollection<USBDeviceInfo> Entries
        {
            get
            {
                return mEntries;
            }
            set
            {
                if (value != mEntries)
                {
                    OnPropertyChanging("Entries");
                    if (mEntries != null)
                        mEntries.CollectionChanged -= Entries_CollectionChanged;
                    mEntries = value;
                    if (mEntries != null)
                        mEntries.CollectionChanged += Entries_CollectionChanged;
                    Entries_CollectionChanged(value, new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
                    OnPropertyChanged("Entries");
                }
            }
        }

        public ICommand ExitApplicationCommand
        {
            get
            {
                if (mExitApplicationCommand == null)
                    mExitApplicationCommand = new RelayCommand(doExitApplicationCommand, canExitApplicationCommand);

                return mExitApplicationCommand;
            }
        }

        public Visibility ExtraMenuItemsVisibility
        {
            get
            {
                return mExtraMenuItemsVisibility;
            }
            set
            {
                if (value != mExtraMenuItemsVisibility)
                {
                    OnPropertyChanging("ExtraMenuItemsVisibility");
                    mExtraMenuItemsVisibility = value;
                    OnPropertyChanged("ExtraMenuItemsVisibility");
                }
            }
        }

        public ConnectionsGroupsViewModel GroupedMenuItems
        {
            get
            {
                return mGroupedMenuItems;
            }
            set
            {
                if (value != mGroupedMenuItems)
                {
                    OnPropertyChanging("GroupedMenuItems");
                    mGroupedMenuItems = value;
                    OnPropertyChanged("GroupedMenuItems");
                }
            }
        }

        public Visibility GroupingSeparatorVisibility
        {
            get
            {
                return mGroupingSeparatorVisibility;
            }
            private set
            {
                if (value != mGroupingSeparatorVisibility)
                {
                    OnPropertyChanging("GroupingSeparatorVisibility");
                    mGroupingSeparatorVisibility = value;
                    OnPropertyChanged("GroupingSeparatorVisibility");
                }
            }
        }

        public ImageSource IconSource
        {
            get
            {
                return mIconSource;
            }
            set
            {
                if (value != mIconSource)
                {
                    OnPropertyChanging("IconSource");
                    mIconSource = value;
                    OnPropertyChanged("IconSource");
                }
            }
        }

        public static bool IsWindows8 => (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor > 1);

        public bool IsWindows8Mode
        {
            get
            {
                return mIsWindows8Mode;
            }
            set
            {
                if (value != mIsWindows8Mode)
                {
                    OnPropertyChanging(nameof(IsWindows8Mode));
                    mIsWindows8Mode = value;
                    MenuActivationMode = GetMenuActivationModeFromWindows8Mode(value);
                    UpdateWindowMode(value);
                    OnPropertyChanged(nameof(IsWindows8Mode));
                }
            }
        }

        public PopupActivationMode MenuActivationMode
        {
            get
            {
                return mMenuActivationMode;
            }
            set
            {
                if (value != mMenuActivationMode)
                {
                    OnPropertyChanging(nameof(MenuActivationMode));
                    mMenuActivationMode = value;
                    OnPropertyChanged(nameof(MenuActivationMode));
                }
            }
        }

        public DeviceViewModel SelectedConnection
        {
            get
            {
                return mSelectedConnection;
            }
            set
            {
                if (value != mSelectedConnection)
                {
                    OnPropertyChanging(nameof(SelectedConnection));
                    mSelectedConnection = value;
                    OnPropertyChanged(nameof(SelectedConnection));
                }
            }
        }

        public ICommand SetExtraMenuItemsVisiblityCommand
        {
            get
            {
                if (mSetExtraMenuItemsVisiblityCommand == null)
                    mSetExtraMenuItemsVisiblityCommand = new RelayCommand(doSetExtraMenuItemsVisiblityCommand, canSetExtraMenuItemsVisiblityCommand);

                return mSetExtraMenuItemsVisiblityCommand;
            }
        }

        public Visibility showAboutMenuCommand
        {
            get
            {
                return canAboutMenuCommand(null) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public ICommand ShowAppBarCommand
        {
            get
            {
                if (mShowAppBarCommand == null)
                    mShowAppBarCommand = new RelayCommand(doShowAppBarCommand, canShowAppBarCommand);

                return mShowAppBarCommand;
            }
        }

        public Visibility showSetExtraMenuItemsVisiblityCommand
        {
            get
            {
                return canSetExtraMenuItemsVisiblityCommand(null) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public ICommand StartupCommand
        {
            get
            {
                if (mStartupCommand == null)
                    mStartupCommand = new RelayCommand(doStartupCommand, canStartupCommand);

                return mStartupCommand;
            }
        }

        public bool StartupEnabled
        {
            get
            {
                return StartUpHandler.IsApplicationStartupForCurrentUser();
            }
            set
            {
                OnPropertyChanging(nameof(StartupEnabled));
                OnPropertyChanged(nameof(StartupEnabled));
            }
        }

        public ConnectionsGroupViewModel UngroupedMenuItems
        {
            get
            {
                return mUngroupedMenuItems;
            }
            set
            {
                if (value != mUngroupedMenuItems)
                {
                    OnPropertyChanging("UngroupedMenuItems");
                    mUngroupedMenuItems = value;
                    OnPropertyChanged("UngroupedMenuItems");
                }
            }
        }

        public string VersionInfo
        {
            get
            {
                Assembly assembly = Assembly.GetEntryAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                return $"{fvi.ProductName} v{fvi.FileMajorPart}.{fvi.FileMinorPart} by {fvi.CompanyName}";
            }
        }

        #endregion Public Properties

        #region Protected Properties

        protected Dispatcher Dispatcher { get; }
        #endregion Protected Properties

        #region Public Methods

        public bool canAboutMenuCommand(object obj)
        {
            //TODO: Place code here to validate when command can run
            return AboutMenuItemEnabled;
        }

        public bool canFlipCommand(object obj)
        {
            //TODO: Place code here to validate when command can run
            return !(((obj as DeviceViewModel)?.IsChanging) ?? false);
        }

        public bool canExitApplicationCommand(object obj)
        {
            //TODO: Place code here to validate when command can run
            return true;
        }

        public bool canSetExtraMenuItemsVisiblityCommand(object obj)
        {
            //TODO: Place code here to validate when command can run
            return !IsWindows8Mode && obj != null;
        }

        public bool canShowAppBarCommand(object obj)
        {
            //TODO: Place code here to validate when command can run
            return IsWindows8Mode;
        }

        public bool canStartupCommand(object obj)
        {
            //TODO: Place code here to validate when command can run
            return true;
        }

        public void doAboutMenuCommand(object obj)
        {
            if (canAboutMenuCommand(obj))
            {
                AboutWindow aw = new AboutWindow();
                aw.DataContext = this;

                aw.ShowDialog();
            }
        }

        public async void doFlipCommand(object obj)
        {
            if (canFlipCommand(obj))
            {
                DeviceViewModel dvm = obj as DeviceViewModel;
                if (obj != null)
                    await dvm.Flip();
            }
        }

        public void doExitApplicationCommand(object obj)
        {
            if (canExitApplicationCommand(obj))
            {
                App.Current?.Shutdown();
            }
        }

        public void doSetExtraMenuItemsVisiblityCommand(object obj)
        {
            if (canSetExtraMenuItemsVisiblityCommand(obj))
            {
                Visibility newState = Visibility.Visible;
                bool newBooleanValue = false;
                if (bool.TryParse(obj.ToString(), out newBooleanValue))
                    newState = (newBooleanValue) ? Visibility.Visible : Visibility.Collapsed;
                else
                {
                    Visibility newVisibilityValue = Visibility.Collapsed;
                    if (Enum.TryParse<Visibility>(obj.ToString(), out newVisibilityValue))
                        newState = newVisibilityValue;
                }
                ExtraMenuItemsVisibility = newState;
                AboutMenuItemEnabled = newState == Visibility.Visible;
            }
        }

        public void doShowAppBarCommand(object obj)
        {
            if (canShowAppBarCommand(obj))
            {
                Window window = App.Current.MainWindow;
                if (window != null)
                    if (window.Visibility == Visibility.Visible)
                        window.SlideIn();
                    else
                        window.SlideOut();
            }
        }

        public void doStartupCommand(object obj)
        {
            if (canStartupCommand(obj))
            {
                OnPropertyChanging(nameof(StartupEnabled));
                if (StartupEnabled)
                    StartUpHandler.RemoveApplicationFromCurrentUserStartup();
                else
                    StartUpHandler.AddApplicationToCurrentUserStartup();

                OnPropertyChanged(nameof(StartupEnabled));
            }
        }

        #endregion Public Methods

        #region Private Methods

        private static PopupActivationMode GetMenuActivationModeFromWindows8Mode(bool value)
        {
            return value ? PopupActivationMode.RightClick : PopupActivationMode.LeftOrRightClick;
        }

        private void Connection_Error(object sender, System.IO.ErrorEventArgs e)
        {
            DeviceViewModel cvm = sender as DeviceViewModel;
            ShowBalloon($"{cvm.FullName}", $"{e.GetException().GetType().Name} + {e.GetException().Message}", icon: BalloonIcon.Error);
        }

        private async Task CreateCollectionContext()
        {
            ConnectionsGroupsViewModel groupedItems = new ConnectionsGroupsViewModel();
            ConnectionsGroupViewModel ungroupedItems = await CreateConnections(Entries).ConfigureAwait(false);
            Connections = ungroupedItems.Clone();
            var groups = ungroupedItems.GroupBy(x => x.GroupName).OrderBy(x => x.Key);

            List<Task> groupTasks = new List<Task>();
            foreach (var group in groups)
                if (!string.IsNullOrWhiteSpace(group.Key))
                {
                    ConnectionsGroupViewModel groupedItem = new ConnectionsGroupViewModel(group.Key);
                    groupedItems.Add(groupedItem);

                    var t = UpdateConnectionGroups(groupedItem, ungroupedItems, group);
                    groupTasks.Add(t);
                }

            await Task.WhenAll(groupTasks.ToArray()).ConfigureAwait(false);

            await Task.Run(() =>
            {
                UngroupedMenuItems = ungroupedItems;
            });

            await Task.Run(() =>
            {
                GroupedMenuItems = groupedItems;
            });

            await Task.Run(() =>
            {
                GroupingSeparatorVisibility =
                    (ungroupedItems != null && ungroupedItems.Count > 0 &&
                     groupedItems != null && groupedItems.Count > 0) ? Visibility.Visible : Visibility.Collapsed;
            });
        }

        private async Task<ConnectionsGroupViewModel> CreateConnections(ObservableCollection<USBDeviceInfo> entries)
        {
            return await Task.Run(() =>
            {
                var localEntries = entries.OrderBy(x => x.Description);

                ConnectionsGroupViewModel localConnections = new ConnectionsGroupViewModel();
                if (localEntries != null)
                    foreach (var entry in localEntries)
                    {
                        var connection = new DeviceViewModel(null) { Entry = entry };
                        connection.Error += Connection_Error;
                        localConnections.Add(connection);
                    }

                return localConnections;
            });
        }

        private void Entries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Task t = Task.Run(() => CreateCollectionContext());
            if (t.Status == TaskStatus.Faulted)
            {
                System.Windows.MessageBox.Show(t.Exception?.Message, t.Exception?.GetType().FullName);
            }
        }

        private void ShowBalloon(string title, string detail)
        {
            ShowBalloon(title, detail, IconHandler.ConnectedSource);
        }

        private void ShowBalloon(string title, string detail, ImageSource imageSource = null, BalloonIcon icon = BalloonIcon.Info, bool useCustom = false)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (useCustom)
                    Balloon = new ConnectionStatusBalloon() { Title = title, Detail = detail, ImageSource = imageSource };
                else
                    BalloonTip = new BalloonTipEventArgs() { Icon = icon, Message = detail, Title = title };
            }));
        }

        private async Task UpdateConnectionGroups(ConnectionsGroupViewModel groupedItems, ConnectionsGroupViewModel ungroupedItems, IGrouping<string, DeviceViewModel> group)
        {
            await Task.Run(() =>
            {
                var localItems = groupedItems;
                var localGroup = group;

                foreach (var connection in group)
                {
                    ungroupedItems.Remove(connection);
                    groupedItems.Add(connection);
                }
            });
        }

        private void UpdateTrayIcon()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                IsWindows8Mode = IsWindows8;
                IconSource = IconHandler.ConnectedSource;
            }));
        }

        private void UpdateWindowMode(bool value)
        {
            Window win = App.Current.MainWindow;
            win.SlideIn();
        }
        #endregion Private Methods
    }
}