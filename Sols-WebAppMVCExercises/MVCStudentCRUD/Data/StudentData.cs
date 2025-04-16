using MVCStudentCRUD.Models;

namespace MVCStudentCRUD.Data {

    public class StudentData {

        // Private constructor
        private StudentData() {
            SetStudentData();
        }

        private static StudentData? _instance;

        private List<Student>? _students;

        // Uses property to return instance
        public static StudentData Instance {
            get {
                if (_instance == null) {
                    _instance = new StudentData();
                }
                // _instance ??= new StudentData();
                return _instance;
            }
        }

        public IEnumerable<Student>? StudentList {
            get {
                return _students;
            }
        }

        public Student? GetStudentById(int targetId) {
            Student? foundStudent = new Student(-1, "NoName", -1);  // Default (fake) student
            if (_students != null) {
                // Ordinary way
                foreach (Student stud in _students) {
                    if (stud.StudentId == targetId) {
                        foundStudent = stud;
                        break;
                    }
                }
                // Linq and delegate and lambda in use
                // foundStudent = _students.FirstOrDefault(x => x.StudentId == targetId);
            }
            return foundStudent;
        }

        public Student? InsertStudent(Student newStudent) {
            Student? insertStudent = null;
            // Only if list exist
            if (_students != null) {
                // Linq and delegate and lambda in use
                int maxId = _students.Max(x => x.StudentId);
                int nextStudentId = maxId + 1;
                insertStudent = new Student(nextStudentId, newStudent.StudentName, newStudent.Age);
                _students.Add(insertStudent);
                // Ordinary way
                //int maxId = 0;
                //foreach (Student stud in _students) {
                //    if (stud.StudentId > maxId) {
                //        maxId = stud.StudentId;
                //    }
                //}
            }
            return insertStudent;
        }

        public void UpdateStudent(Student redStudent) {
            if (_students != null) {
                foreach (Student stud in _students) {
                    if (stud.StudentId == redStudent.StudentId) {
                        stud.StudentName = redStudent.StudentName;
                        stud.Age = redStudent.Age;
                        break;
                    }
                }
            }
        }

        public void DeleteStudent(int targetId) {
            Student? foundStudent = null;
            if (_students != null) {
                foreach (Student stud in _students) {
                    if (stud.StudentId == targetId) {
                        foundStudent = stud;
                    }
                }
                if (foundStudent != null) {
                    _students.Remove(foundStudent);
                }
            }
        }

        private void SetStudentData() {
            _students = new List<Student> {
                            new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                            new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                            new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                            new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                            new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                            new Student() { StudentId = 6, StudentName = "Chris" , Age = 17 } ,
                            new Student() { StudentId = 7, StudentName = "Rob" , Age = 19 }
                        };
        }

    }
}
