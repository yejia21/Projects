﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;
using AutomationTestAssistantCore;

namespace AutomationTestAssistantDesktopApp
{
    public class TestsViewModel : Test, INotifyPropertyChanged
    {
        private bool selected;
        public bool IsSelected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }

        public string UserName { get; set; }

        private void OnPropertyChanged(string property)
        {
        }

        public TestsViewModel(Test t)
        {
            base.Name = t.Name;
            base.ClassName = t.ClassName;
            base.FullName = t.FullName;
            base.MethodId = t.MethodId;
            base.AdditionDate = t.AdditionDate;
            base.DeletionDate = t.DeletionDate;
            IsSelected = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
