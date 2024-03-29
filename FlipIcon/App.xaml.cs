﻿using System;
using System.Windows;
using FlipIcon.Handler;
using FlipIcon.Windows;

namespace FlipIcon
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ProgramVersions history;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherUnhandledException += Application_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Window win = new Windows.MainWindow();
            App.Current.MainWindow = win;
            win.SlideIn();

            //create the notifyicon (it's a resource declared in NotifyIconResources.xaml
            //notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
            //notifyIcon = new TaskbarIcon() { DataContext = new MainViewModel() };

        }

        public static ProgramVersions History
        {
            get
            {
                if (history == null)
                    history =
                        new ProgramVersions(
                            new ProgramVersion("0.2",
                                "Import USBDeviceInfo classes and helpers"),
                            new ProgramVersion("0.1",
                                "First edition cloned from Vpn Icon")
                            );
                return history;
            }
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            HandleException(ex);
        }

        void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            e.Handled = true;
            HandleException(ex);
        }

        static void HandleException(Exception ex)
        {
            if (ex != null)
            {
                //MessageBox.Show(ex.Message + Environment.NewLine + "Stack: " + ex.StackTrace, ex.Source);
                ExceptionWindow ew = new ExceptionWindow
                {
                    ExceptionObject = ex
                };
                ew.ShowDialog();
            }
        }


        protected override void OnExit(ExitEventArgs e)
        {
            //notifyIcon.Dispose(); //the icon would clean up automatically, but this is cleaner
            base.OnExit(e);
        }

    }
}
