using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;
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

namespace StudentManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public ObservableCollection<Student> _people;
        public AddWindow(ObservableCollection<Student> people)
        {
            InitializeComponent();
            AddWindowVM vM = new AddWindowVM(people);
            DataContext = vM;
            _people = people;
            vM.CloseWindow_ = () => Close();
        }
    }
}
