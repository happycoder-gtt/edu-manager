using EduManager.DAL.Models;
using EduManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduManager.BLL.Services
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository 
                            = new StudentRepository();

        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }
    }
}
