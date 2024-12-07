using Domain;

namespace Infrastructure;

public interface IDepartmentService
{
    bool Create(Department department);
    List<Department> GetAll();
    Department GetById(int id);
    bool Update(Department department);
    bool Delete(int id);
}