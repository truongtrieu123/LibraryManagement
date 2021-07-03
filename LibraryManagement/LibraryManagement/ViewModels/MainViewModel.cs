﻿using LibraryManagement.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public ICommand UpdateView { get; set; }
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public MainViewModel()
        {
            Console.WriteLine("MainViewModel");
            _selectedViewModel = new AboutUsViewModel(this);
            UpdateView = new UpdateMainViewCommand(this);
        }
    }
}
