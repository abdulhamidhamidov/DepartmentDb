using Domain;

namespace Infrastructure;

public interface IEmployeeService
{
   bool Create(Employee employee);
   List<Employee> GetAll();
   Employee GetById(int id);
   bool Update(Employee employee);
   bool Delete(int id);
}