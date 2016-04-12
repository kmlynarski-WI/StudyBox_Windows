﻿using System;
using Windows.UI.Xaml.Media.Animation;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using StudyBox.Core.Messages;
using StudyBox.Core.Interfaces;

namespace StudyBox.Core.ViewModels
{
    public class MenuControlViewModel : ExtendedViewModelBase
    {
        private readonly IAccountService _accountService;
        private bool _isSearchOpen = false;
        private bool _isPaneOpen = false;
        private bool _logoutButtonVisibility;
        private RelayCommand _openMenuCommand;
        private RelayCommand _showSearchPanelCommand;
        private RelayCommand _cancelSearchingCommand;
        private RelayCommand _doSearchCommand;
        private RelayCommand _logoutCommand;
        private string _searchingContent;
        private string _titleBar;
        private bool _searchButtonVisibility;
        private bool _saveButtonVisibility;
        private bool _exitButtonVisibility;

        public MenuControlViewModel(INavigationService navigationService, IAccountService accountService) : base(navigationService)
        {
            Messenger.Default.Register<MessageToMenuControl>(this, x=> HandleMenuControlMessage(x.SearchButton,x.SaveButton,x.ExitButton,x.TitleString));
            SearchButtonVisibility = true;
            _accountService = accountService;
            LogoutButtonVisibility = _accountService.IsUserLoggedIn();
        }

        public string TitleBar
        {
            get
            {
                if (string.IsNullOrEmpty(_titleBar))
                    return StringResources.GetString("StudyBox");
                else
                    return _titleBar;
            }
            set
            {
                if (_titleBar != value)
                {
                    _titleBar = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string SearchingContent
        {
            get
            {
                return _searchingContent;
            }
            set
            {
                if (_searchingContent != value)
                {
                    _searchingContent = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsSearchOpen
        {
            get
            {
                return _isSearchOpen;
            }
            set
            {
                if (_isSearchOpen != value)
                {
                    _isSearchOpen = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsPaneOpen
        {
            get
            {
                return _isPaneOpen;
            }
            set
            {
                if (_isPaneOpen != value)
                {
                    _isPaneOpen = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool SearchButtonVisibility
        {
            get
            {
                return _searchButtonVisibility; 
            }
            private set
            {
                if (_searchButtonVisibility != value)
                {
                    _searchButtonVisibility = value;
                    if (_searchButtonVisibility == true)
                    {
                        SaveButtonVisibility = false;
                        ExitButtonVisibility = false;
                    }
                    RaisePropertyChanged();
                }
            }
        }

     

        public bool SaveButtonVisibility
        {
            get
            {
                return _saveButtonVisibility;
            }
            private set
            {
                if (_saveButtonVisibility != value)
                {
                    _saveButtonVisibility = value;
                    if (_saveButtonVisibility == true)
                    {
                        SearchButtonVisibility = false;
                        ExitButtonVisibility = false;
                    }
                    RaisePropertyChanged();
                }
            }
        }

        public bool ExitButtonVisibility
        {
            get
            {
                return _exitButtonVisibility;
            }
            private set
            {
                if (_exitButtonVisibility != value)
                {
                    _exitButtonVisibility = value;
                    if (_exitButtonVisibility == true)
                    {
                        SearchButtonVisibility = false;
                        SaveButtonVisibility = false;
                    }
                    RaisePropertyChanged();
                }
            }
        }

        public bool LogoutButtonVisibility
        {
            get
            {
                return _logoutButtonVisibility;
            }
            set
            {
                if (_logoutButtonVisibility != value)
                {
                    _logoutButtonVisibility = value;
                    RaisePropertyChanged();
                }
            }
        }

        public RelayCommand OpenMenuCommand
        {
            get { return _openMenuCommand ?? (_openMenuCommand = new RelayCommand(OpenMenu)); }
        }

        public RelayCommand ShowSearchPanelCommand
        {
            get { return _showSearchPanelCommand ?? (_showSearchPanelCommand = new RelayCommand(ShowSearchPanel)); }
        }

        public RelayCommand CancelSearchingCommand
        {
            get { return _cancelSearchingCommand ?? (_cancelSearchingCommand = new RelayCommand(CancelSearching)); }
        }

        public RelayCommand DoSearchCommand
        {
            get { return _doSearchCommand ?? (_doSearchCommand = new RelayCommand(DoSearch)); }
        }

        public RelayCommand LogoutCommand
        {
            get { return _logoutCommand ?? (_logoutCommand = new RelayCommand(Logout)); }
        }

        private void DoSearch()
        {
            //TODO SEARCH ACTION
        }

        private void CancelSearching()
        {
            if (IsSearchOpen)
            {
                IsSearchOpen = false;
                SearchButtonVisibility = true;
            }
            Messenger.Default.Send<ReloadMessageToDecksList>(new ReloadMessageToDecksList(true));
        }
        private void OpenMenu()
        {
            IsPaneOpen = !IsPaneOpen && LogoutButtonVisibility;
        }

        private void ShowSearchPanel()
        {
            IsSearchOpen = IsSearchOpen != true;
            if (IsSearchOpen)
                ExitButtonVisibility = true;
            else
                SearchButtonVisibility = true;
        }

        private void Logout()
        {
            _accountService.LogOut();
            IsPaneOpen = false;
            LogoutButtonVisibility = false;
            NavigationService.NavigateTo("LoginView");
        }

        private void HandleMenuControlMessage(bool search, bool save, bool exit, string title)
        {
            SearchButtonVisibility = search;
            SaveButtonVisibility = save;
            ExitButtonVisibility = exit;
            if (String.IsNullOrEmpty(title))
            {
                TitleBar = StringResources.GetString("StudyBox");
            }
            else
            {
                TitleBar = title;
            }
            LogoutButtonVisibility = _accountService.IsUserLoggedIn();
        }
    }
}
