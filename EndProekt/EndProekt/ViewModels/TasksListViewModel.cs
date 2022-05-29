using EndProekt.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EndProekt.ViewModels
{
    public class TasksListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TaskViewModel> Tasks { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateTaskCommand { protected set; get; }
        public ICommand DeleteTaskCommand { protected set; get; }
        public ICommand SaveTaskCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        TaskViewModel selectedTask;
        public INavigation Navigation { get; set; }
        public TasksListViewModel()
        {
            Tasks = new ObservableCollection<TaskViewModel>();
            CreateTaskCommand = new Command(CreateTask);
            DeleteTaskCommand = new Command(DeleteTask);
            SaveTaskCommand = new Command(SaveTask);
            BackCommand = new Command(Back);
        }
        public TaskViewModel SelectedTask
        {
            get { return selectedTask; }
            set
            {
                if (selectedTask != value)
                {
                    TaskViewModel tempTask = value;
                    selectedTask = tempTask;
                    OnPropertyChanged("SelectedTask");
                    Navigation.PushAsync(new HomePage(tempTask));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private void CreateTask()
        {
            Navigation.PushAsync(new HomePage(new TaskViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveTask(object taskObject)
        {
            TaskViewModel task = taskObject as TaskViewModel;
            if (task != null && task.IsValid && !Tasks.Contains(task))
            {
                Tasks.Add(task);
            }
            Back();
        }
        private void DeleteTask(object taskObject)
        {
            TaskViewModel task = taskObject as TaskViewModel;
            if (task != null)
            {
                Tasks.Remove(task);
            }
            Back();
        }
    }
}
