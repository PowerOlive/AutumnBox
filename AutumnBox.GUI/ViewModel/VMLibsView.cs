﻿using AutumnBox.GUI.Model;
using AutumnBox.GUI.MVVM;
using AutumnBox.GUI.Util.Bus;
using AutumnBox.OpenFramework.Management;
using System.Collections.Generic;
using System.Windows.Input;

namespace AutumnBox.GUI.ViewModel
{
    class VMLibsView : ViewModelBase
    {
        public LibDock SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                RaisePropertyChanged();
            }
        }
        private LibDock _selectedItem;

        public IEnumerable<LibDock> Libs
        {
            get => _libs; set
            {
                _libs = value;
                RaisePropertyChanged();
            }
        }
        private IEnumerable<LibDock> _libs;

        public FlexiableCommand ShowInformation
        {
            get => _showInformation; set
            {
                _showInformation = value;
                RaisePropertyChanged();
            }
        }
        private FlexiableCommand _showInformation;

        public VMLibsView()
        {
            OpenFxObserver.Instance.Loaded += (s, e) =>
            {
                Load();
            };
            ShowInformation = new FlexiableCommand(() =>
            {
                SelectedItem.Lib.ShowInformation();
            });
        }

        public void Load()
        {
            Libs = LibDock.From(OpenFx.LibsManager.Librarians);
        }
    }
}
