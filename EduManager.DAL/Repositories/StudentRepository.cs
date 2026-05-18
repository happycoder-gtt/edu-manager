using EduManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduManager.DAL.Repositories
{
    public class StudentRepository
    {
        //Phương thức lấy tất cả Student
        public List<Student> GetAll()
        {
            using var db = new EduManagerDbContext();
            return db.Students.ToList();
            //Select * From Students
        }

        //Phương thức lấy ra 1 Student
        public Student GetById(int id)
        {
            using var db = new EduManagerDbContext();
            return db.Students.
                Where(q => q.StudentId == id).FirstOrDefault();
        }

        //Phương thức thêm mới một sinh viên
        public void Add(Student student)
        {
            using var db = new EduManagerDbContext();
            db.Students.Add(student);
            db.SaveChanges();
            //Insert into Students values ...
        }

        //Cập nhật Student
        public void Update(Student student)
        {
            using var db = new EduManagerDbContext();
            db.Students.Update(student);
            db.SaveChanges();
            //Update ...
        }
        
        //Xóa Student
        public void Delete(int id)
        {
            using var db = new EduManagerDbContext();
            var student = db.Students.Find(id); //Select * From Students Where StudentId == id
            if (student == null)
                return;
            db.Students.Remove(student);
            db.SaveChanges();
            //Delete ...
        }
    }
}
