using BlApi;
using BO;
using System.Collections.Generic;
using System.Windows;

namespace PL.Manager;

/// <summary>
/// Interaction logic for Gantt.xaml
/// </summary>
public partial class Gantt : Window
{
    private readonly IBl bl = Factory.Get();
    public IEnumerable<TaskInGantt> GanttList
    {
        get { return (IEnumerable<TaskInGantt>)GetValue(MyPropertyProperty); }
        set { SetValue(MyPropertyProperty, value); }
    }

    // Using a DependencyProperty as the backing store for OpenDialoge.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.Register("GanttList", typeof(IEnumerable<TaskInGantt>), typeof(Gantt));



    public Gantt()
    {
        try
        {
            GanttList = bl.Task.GanttList();
        }
        catch
        {
            throw new Exception("The tasks is not schedule yet\n");
        }
        InitializeComponent();
    }
}
