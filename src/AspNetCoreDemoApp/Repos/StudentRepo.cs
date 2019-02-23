using AspNetCoreDemoApp.Common;
using AspNetCoreDemoApp.Model;
using AspNetCoreDemoApp.Model.Params;
using AspNetCoreDemoApp.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Repos
{
    public class StudentRepo
    {
        private readonly Context _context = new Context();
        public Student Find(AuthenticationParams model)
        {
            var student = _context.Student.Where(s => s.Username == model.Username && s.Password == model.Password)
                              .FirstOrDefault();
            return student;
        }

        public Student Find(string token)
        {
            var student = _context.Student.Where(s => s.Token == token)
                .FirstOrDefault();
            return student;
        }

        public Student Create(Student student)
        {
            var students = _context.Student;
            student.Token = Guid.NewGuid().ToString();
            students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public string SetToken(AuthenticationParams model)
        {
            var student = Find(model);

            if (student != null)
            {
                student.Token = Guid.NewGuid().ToString();
                _context.SaveChanges();
            }
            return student?.Token;
        }

        public string GetToken(AuthenticationParams model)
        {
            return Find(model).Token;
        }
    }
}
