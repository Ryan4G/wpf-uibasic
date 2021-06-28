using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIModeMVVM.Models;

namespace UIModeMVVM.DB
{
    public class LocalDB
    {
        private List<Student> _students;

        public LocalDB()
        {
            init();
        }

        private void init() {

            _students = new List<Student>();

            _students.Add(new Student
            {
                Id = 10001,
                Name = "小明"
            });

            _students.Add(new Student
            {
                Id = 10002,
                Name = "小红"
            });

            _students.Add(new Student
            {
                Id = 10003,
                Name = "小兰"
            });

            _students.Add(new Student
            {
                Id = 10004,
                Name = "小烁"
            });
            
            _students.Add(new Student
            {
                Id = 10005,
                Name = "小意"
            });
            
            _students.Add(new Student
            {
                Id = 10006,
                Name = "小米"
            });
            
            _students.Add(new Student
            {
                Id = 10007,
                Name = "小企"
            });
            
            _students.Add(new Student
            {
                Id = 10008,
                Name = "小哇"
            });
            
            _students.Add(new Student
            {
                Id = 10009,
                Name = "小手"
            });
        }

        public List<Student> GetStudents()
        {
            return _students;
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public void DeleteStudent(int id)
        {
            var stu = _students.FirstOrDefault(x => x.Id == id);

            if (stu != null)
            {
                _students.Remove(stu);
            }
        }

        public List<Student> GetStudentsByName(string name)
        {
            var matchs = _students.FindAll(x => x.Name.Contains(name));
            return matchs;
        }
        
        public Student GetStudentById(int id)
        {
            var match = _students.FirstOrDefault(x => x.Id == id);
            return match;
        }
    }
}
