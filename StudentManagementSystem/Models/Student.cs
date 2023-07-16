using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public partial class Student : ObservableObject
    {
        [ObservableProperty]
        public string firstName;
        [ObservableProperty]
        public string lastName;
        [ObservableProperty]
        public string image;
        [ObservableProperty]
        public DateTime dateOfBirth;
        [ObservableProperty]
        public string gPA;

        public Student(string firstName, string lastName, string image, DateTime dateOfBirth, string gpa)
        {
            FirstName = firstName;
            LastName = lastName;
            Image = image;
            DateOfBirth = dateOfBirth;
            GPA = gpa;
        }
    }
}