using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL.Manager
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        private readonly IBl bl = Factory.Get();

        public class DataContext
        {
            public BO.Task Task;

        }
        public bool AddMode {  get; set; }

        public List<TaskInList> AllTasks { get; set; }  

        public bool OpenDialoge
        {
            get { return (bool)GetValue(OpenDialogeProperty); }
            set { SetValue(OpenDialogeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenDialoge.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenDialogeProperty =
            DependencyProperty.Register("OpenDialoge", typeof(bool), typeof(TaskWindow));



        public BO.Task Task
        {
            get { return (BO.Task)GetValue(TaskProperty); }
            set { SetValue(TaskProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Task.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TaskProperty =
            DependencyProperty.Register("Task", typeof(BO.Task), typeof(TaskWindow));

        public bool IsManager { set; get; }
        public TaskWindow(bool isManager,int id = 0)
        {
            IsManager = isManager;
            AddMode = id == 0;
            OpenDialoge = false;
            if (AddMode)
            {
                Task = new();
                Task.CreatedDate = DateTime.Now;  
            }
            else
                Task = bl.Task.Read(id)!;

            if (Task.Dependencies is null)
                Task.Dependencies = new();

            AllTasks = bl.Task.ReadAll().ToList();
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AddMode)
                {
                    int id = bl.Task.Create(Task);
                    MessageBox.Show($"the new task is {id}");
                }
                else
                {
                    bl.Task.Update(Task);
                    MessageBox.Show($"the task {Task.Id} sucsseful update");

                }
                this.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void EditDepWindow(object sender, RoutedEventArgs e)=>OpenDialoge = true;

        private void AddCurrentDep(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ListView listView = sender as ListView;
                TaskInList selected = listView.SelectedItem as TaskInList;
                if (selected != null) 
                    Task.Dependencies.Add(selected);
                BO.Task tmp = Task;
                Task = null;
                Task = tmp;
            }
            catch { }
        }

        private void DeleteDep(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                TaskInList selected = btn.Tag as TaskInList;
                if (selected != null)
                    Task.Dependencies.Remove(selected);
                BO.Task tmp = Task;
                Task = null;
                Task = tmp;
            }
            catch { }
        }
    }
}
