

using LinqGroupJoin;

var studentList = new List<Student>();  

studentList.Add(new Student { StudentID = 1, StudentName = "Ali", ClassID = 1});
studentList.Add(new Student { StudentID = 2, StudentName = "Ayşe", ClassID = 2 });
studentList.Add(new Student { StudentID = 3, StudentName = "Mehmet", ClassID = 1 });
studentList.Add(new Student { StudentID = 4, StudentName = "Fatma", ClassID = 3 });
studentList.Add(new Student { StudentID = 5, StudentName = "Ahmet", ClassID = 2 });

var classList = new List<Class>();

classList.Add(new Class { ClassID = 1, ClassName = "Matematik" });
classList.Add(new Class { ClassID = 2, ClassName = "Türkçe" });
classList.Add(new Class { ClassID = 3, ClassName = "Kimya" });

var studentAndClass = classList.GroupJoin(studentList,
                                          classes => classes.ClassID,
                                          student => student.ClassID,
                                          (classes, classGroup) => new
                                          {
                                              ClassName = classes.ClassName,
                                              Students = classGroup

                                          });

foreach (var classes in studentAndClass)
{
    Console.WriteLine($"↓ {classes.ClassName} dersi alan öğrenciler ↓");
   
    foreach (var student in classes.Students)
    {
        Console.WriteLine($"{student.StudentName}");
    }
}