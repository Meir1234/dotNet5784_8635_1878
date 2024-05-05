using BlApi;
using PL.Engineer;
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
using BO;

namespace PL.Manager;

/// <summary>
/// Interaction logic for TasksListWindows.xaml
/// </summary>
public partial class TasksListWindows : Window
{

    private readonly IBl _bl = Factory.Get();



    public ObservableCollection<BO.TaskInList> Tasks

    {
        get { return (ObservableCollection<BO.TaskInList>)GetValue(TasksProp); }
        set { SetValue(TasksProp, value); }
    }

    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TasksProp =
        DependencyProperty.Register(nameof(Tasks), typeof(ObservableCollection<BO.TaskInList>), typeof(TasksListWindows));

    public TasksListWindows()
    {
        Tasks = new(_bl.Task.ReadAll());
        InitializeComponent();
    }

    private void SelectGroup(object sender, SelectionChangedEventArgs e)
    {
        ComboBox combo = sender as ComboBox;
        Status selected = (Status)combo.SelectedItem;

        if (selected == Status.All)
            Tasks = new(_bl.Task.ReadAll());
        else
            Tasks = new(_bl.Task.ReadAll(task => task.Status == selected));
    }

    private void AddTask_btn(object sender, RoutedEventArgs e)
    {

    }
}
