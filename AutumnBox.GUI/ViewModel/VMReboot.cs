﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/15 18:31:08 (UTC +8:00)
** desc： ...
*************************************************/

using AutumnBox.Basic.Device;
using AutumnBox.GUI.MVVM;
using System.Windows.Input;

namespace AutumnBox.GUI.ViewModel
{
    class VMReboot : ViewModelBase
    {
        public DeviceBasicInfo CurrentDevice { get; set; }

        public ICommand ToSystem => _toSystem;
        private FlexiableCommand _toSystem;

        public ICommand ToRecovery => _toRecovery;
        private FlexiableCommand _toRecovery;

        public ICommand ToFastboot => _toFastboot;
        private FlexiableCommand _toFastboot;

        public ICommand To9008 => _to9008;
        private FlexiableCommand _to9008;

        public VMReboot()
        {
            InitCommands();
            InitEvents();
        }

        private void InitCommands()
        {
            _toSystem = new FlexiableCommand(() =>
            {
                DeviceRebooter.Reboot(CurrentDevice, RebootOptions.System);
            })
            { CanExecuteProp = false };
            _toRecovery = new FlexiableCommand(() =>
            {
                DeviceRebooter.Reboot(CurrentDevice, RebootOptions.Recovery);
            })
            { CanExecuteProp = false }; ;
            _toFastboot = new FlexiableCommand(() =>
            {
                DeviceRebooter.Reboot(CurrentDevice, RebootOptions.Fastboot);
            })
            { CanExecuteProp = false }; ;
            _to9008 = new FlexiableCommand(() =>
            {
                DeviceRebooter.Reboot(CurrentDevice, RebootOptions.Snapdragon9008);
            })
            { CanExecuteProp = false };
        }

        private void InitEvents()
        {
            Util.Bus.DeviceSelectionObserver.Instance.SelectedDevice += DeviceSelectionChanged;
            Util.Bus.DeviceSelectionObserver.Instance.SelectedNoDevice += SelectedNone;
        }

        private void SelectedNone(object sender, System.EventArgs e)
        {
            _to9008.CanExecuteProp = false;
            _toSystem.CanExecuteProp = false;
            _toFastboot.CanExecuteProp = false;
            _toRecovery.CanExecuteProp = false;
        }

        private void DeviceSelectionChanged(object sender, System.EventArgs e)
        {
            _to9008.CanExecuteProp = true;
            _toSystem.CanExecuteProp = true;
            _toFastboot.CanExecuteProp = true;
            _toRecovery.CanExecuteProp = CurrentDevice.State != DeviceState.Fastboot;
        }
    }
}