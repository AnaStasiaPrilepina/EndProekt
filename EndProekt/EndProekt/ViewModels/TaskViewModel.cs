using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using EndProekt.Models;

namespace EndProekt.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        TasksListViewModel lvm;
        public Task Task { get; private set; }
        public TaskViewModel()
        {
            Task = new Task();
        }

        public TasksListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if(lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string Name
        {
            get { return Task.Name; }
            set
            {
                if (Task.Name != value)
                {
                    Task.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Description
        {
            get { return Task.Description; }
            set
            {
                if (Task.Description != value)
                {
                    Task.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public string Who
        {
            get { return Task.Who; }
            set
            {
                if (Task.Who != value)
                {
                    Task.Who = value;
                    OnPropertyChanged("Who");
                }
            }
        }
        public string Status
        {
            get { return Task.Status; }
            set
            {
                if (Task.Status != value)
                {
                    Task.Status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim()))) || ((!string.IsNullOrEmpty(Description.Trim()))) 
                    || ((!string.IsNullOrEmpty(Who.Trim()))) || ((!string.IsNullOrEmpty(Status.Trim())));
            }
        }

        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
