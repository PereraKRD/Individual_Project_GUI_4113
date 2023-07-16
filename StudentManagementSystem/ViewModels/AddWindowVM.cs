using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagementSystem.ViewModels
{
    public partial class AddWindowVM : ObservableObject
    {
        private readonly ObservableCollection<Student> _people;
        [ObservableProperty]
        public string firstName;
        [ObservableProperty]
        public string lastName;
        [ObservableProperty]
        public string imagePath;
        [ObservableProperty]
        public DateTime dateOfBirth = DateTime.Now;
        [ObservableProperty]
        public string gPA;
        public Action CloseWindow_ { get; set; }

        public AddWindowVM(ObservableCollection<Student> people)
        {
            _people = people;
        }
        public AddWindowVM()
        {

        }


        [RelayCommand]
        private void Save()
        {
            // Check if any fields are empty
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(ImagePath) || string.IsNullOrWhiteSpace(GPA))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!(Regex.IsMatch(FirstName, @"^[a-zA-Z\s]+$") && Regex.IsMatch(LastName, @"^[a-zA-Z\s]+$")))
            {
                MessageBox.Show("First name and Last name cannot contains any character other than letters.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsValidGPA(GPA))
            {
                MessageBox.Show("GPA should be a number between 0 and 4.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Add the new student to the list
            _people.Add(new Student(FirstName, LastName, ImagePath, DateOfBirth, GPA));
            CloseWindow_();
        }


        [RelayCommand]
        private void Browse()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                ImagePath = selectedFilePath;
            }
        }

        [RelayCommand]
        private void Cancel()
        {
            CloseWindow_();
        }

        [RelayCommand]
        public static void CloseWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
        }

        private bool IsValidGPA(string gpa)
        {
            double result;
            if (double.TryParse(gpa, out result))
            {
                if (result >= 0 && result <= 4)
                    return true;
            }
            return false;
        }
    }
}
