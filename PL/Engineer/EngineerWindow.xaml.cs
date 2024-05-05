using BlApi;
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

    public bool AddMode { set; get; }
    public bool IsManager { set; get; }


    public EngineerWindow(bool isManager, int id = 0)
    {
        IsManager = isManager;
        AddMode = id == 0;

        if (AddMode)
            Engineer = new BO.Engineer() { EngineerTask = new() };
        else
            Engineer = _bl.Engineer.Read(id)!;

        InitializeComponent();
    }
}
