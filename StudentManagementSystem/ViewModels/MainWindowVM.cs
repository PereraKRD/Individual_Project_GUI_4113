using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagementSystem.Models;
using StudentManagementSystem.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagementSystem.ViewModels
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> people = new();

        public MainWindowVM()
        {
            People.Add(new Student("John", "Doe", "/Images/1.png", new DateTime(1990, 2, 3), "3.5"));
            People.Add(new Student("Jane", "Doe", "/Images/2.png", new DateTime(1992, 5, 4), "3.2"));
            People.Add(new Student("Bob", "Smith", "/Images/3.png", new DateTime(1991, 1, 2), "3.8"));
        }

        [RelayCommand]
        public void AddPerson()
        {
            var window = new AddWindow(People);
            window.Show();
        }

        [RelayCommand]
        private void EditPerson(Student student)
        {
            var editWindow = new EditWindow(student);
            editWindow.Show();
        }


        [RelayCommand]
        private void DeletePerson(Student student)
        {
            people.Remove(student);
            MessageBox.Show($"{student.FirstName} was removed Successfully !!");
        }

        [RelayCommand]
        public static void CloseWindow()
        {
            Application.Current.Shutdown();
        }


    }
}
