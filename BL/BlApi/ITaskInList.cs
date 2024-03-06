using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;

internal interface ITaskInList
{
    public List<Task> ReadAll();
    public Task? Build(int id);

    public int Add(BO.Task item);

    public void Update(BO.Task item);

    public void Delete(int id);


    public int Create(BO.Student item);
    public BO.Student? Read(int id);
    public IEnumerable<BO.StudentInList> ReadAll();
    public void Update(BO.Student item);
    public void Delete(int id);
    public BO.StudentInCourse GetDetailedCourseForStudent(int StudentId, int CourseId);

}
