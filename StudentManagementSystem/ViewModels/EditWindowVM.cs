using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagementSystem.ViewModels
{
    public partial class EditWindowVM : ObservableObject
    {
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
        public EditWindowVM()
        {
        }

        public EditWindowVM(Student person, Action closeWindow)
        {
            LoadStudent(person);
            selectedStudent = person;
            CloseWindow_ = closeWindow;
        }

        [ObservableProperty]
        public Student selectedStudent;

        private void LoadStudent(Student student)
        {
            FirstName = student.FirstName;
            LastName = student.LastName;
            ImagePath = student.Image;
            DateOfBirth = student.DateOfBirth;
            GPA = student.GPA;
        }

        [RelayCommand]
        private void Browse()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                SelectedStudent.Image = selectedFilePath;
                ImagePath = selectedFilePath;
            }
        }
        [RelayCommand]
        private void Edit()
        {
            if (!(Regex.IsMatch(FirstName, @"^[a-zA-Z\s]+$") && Regex.IsMatch(LastName, @"^[a-zA-Z\s]+$")))
            {
                MessageBox.Show("First name and Last name cannot contains any character other than letters.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(ImagePath) || string.IsNullOrEmpty(GPA))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsValidGPA(GPA))
            {
                MessageBox.Show("GPA should be a number between 0 and 4.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SelectedStudent.FirstName = FirstName;
            SelectedStudent.LastName = LastName;
            SelectedStudent.DateOfBirth = DateOfBirth;
            SelectedStudent.GPA = GPA;
            SelectedStudent.Image = ImagePath;


            CloseWindow_();
        }
        [RelayCommand]
        private void Cancel()
        {
            CloseWindow_();
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
