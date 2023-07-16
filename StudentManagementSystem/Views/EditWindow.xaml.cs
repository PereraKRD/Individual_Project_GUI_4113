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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public ObservableCollection<Student> _people;
        public EditWindow(Student person)
        {
            InitializeComponent();
            EditWindowVM vm = new EditWindowVM(person, Close);
            DataContext = vm;
        }
    }
}
