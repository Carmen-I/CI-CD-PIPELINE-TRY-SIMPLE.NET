using System.ComponentModel;

namespace MVCStudentCRUD.Models {
    public class Student {

        public Student() { }

        public Student(int InStudentId, string? inStudentname, int inAge) {
            StudentId = InStudentId;
            StudentName = inStudentname;
            Age = inAge;
        }

        [DisplayName("Ident.")]
        public int StudentId { get; set; }

        [DisplayName("Name of student")]
        public string? StudentName { get; set; }

        public int Age { get; set; }

    }
}
