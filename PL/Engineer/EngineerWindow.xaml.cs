using BlApi;
using BO;
using PL.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PL.Engineer;

/// <summary>
/// Interaction logic for EngineerWindow.xaml
/// </summary>
public partial class EngineerWindow : Window
{
    private readonly IBl _bl = Factory.Get();

    public BO.Engineer Engineer
    {
        get { return (BO.Engineer)GetValue(EngineerProperty); }
        set { SetValue(EngineerProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Engineer.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty EngineerProperty =
        DependencyProperty.Register("Engineer", typeof(BO.Engineer), typeof(EngineerWindow));




    public BO.Task Task
    {
        get { return (BO.Task)GetValue(TaskProperty); }
        set { SetValue(TaskProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Task.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TaskProperty =
        DependencyProperty.Register("Task", typeof(BO.Task), typeof(EngineerWindow));




    public IEnumerable<TaskInList> MyTasks
    {
        get { return (IEnumerable<TaskInList>)GetValue(MyTasksProperty); }
        set { SetValue(MyTasksProperty, value); }
    }

    // Using a DependencyProperty as the backing store for MyTasks.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MyTasksProperty =
        DependencyProperty.Register("MyTasks", typeof(IEnumerable<TaskInList>), typeof(EngineerWindow));




    public bool AddMode { set; get; }
    public bool IsManager { set; get; }


    public EngineerWindow(bool isManager, int id = 0)
    {
        IsManager = isManager;
        AddMode = id == 0;
        if (AddMode)
            Engineer = new();
        else
        {
            Engineer = _bl.Engineer.Read(id);
            MyTasks = _bl.Task.EngineerTasks(id, true);
        }

        if (Engineer.EngineerTask is null)
            Engineer.EngineerTask = new();

        InitializeComponent();
    }

    private void Update(object sender, RoutedEventArgs e)
    {
        try
        {
            if (AddMode)
            {
                _bl.Engineer.Create(Engineer);
                //TODO
                MessageBox.Show("Succseful create", "Title", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _bl.Engineer.Update(Engineer);
                //Engineer engineer = LastWindowVM.TasksList!.First(x => x.ID == vm.Engineer.ID);
                //int index = LastWindowVM.TasksList!.IndexOf(engineer);
                //LastWindowVM.TasksList[index] = vm.Engineer;
                //TODO
                MessageBox.Show("Succseful update", "Title", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            this.Close();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }   
    }

    private void FindTask(object sender, RoutedEventArgs e)
    {
        new TasksListWindows(Engineer.Id).ShowDialog();
        MyTasks = _bl.Task.EngineerTasks(Engineer.Id, true); 
    }

    private void ViewTask(object sender, MouseButtonEventArgs e)
    {
        try
        {
            ListView listView = sender as ListView;
            TaskInList selected = (TaskInList)listView.SelectedItem;
            new TaskWindow(false, selected.Id).Show();
        }
        catch { }
    }
}
