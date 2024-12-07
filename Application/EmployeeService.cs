using Domain;
using Infrastructure;
using Npgsql;
using Dapper;
namespace Application;

public class EmployeeService : IEmployeeService
{
    public bool Create(Employee employee)
    {
        try
        {
            using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
            {
                var sql = "insert into employee(fullname, position, salary, branchid)values (@FullName, @Position, @Salary, @BranchId);";
                var res = connection.Execute(sql,employee);
                return res > 0;
            }   

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public List<Employee> GetAll()
    {
        try
        {
            using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
            {
                var sql = "select * from employee";
                var res = connection.Query<Employee>(sql).ToList();
                return res;
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public Employee GetById(int id)
    {
        try
        {
            using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
            {
                var sql = "select * from employee where id=@Id";
                var res = connection.QuerySingle<Employee>(sql,new {Id=id});
                return res;
            } 

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Update(Employee employee)
    {
        try
        {
            using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
            {
                var sql = "update employee set fullname=@FullName,position=@Position,salary=@Salary,branchid=@BranchId where id=@Id;";
                var res = connection.Execute(sql,employee);
                return res > 0;
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
            {
                var sql = "delete from employee where id=@Id";
                var res = connection.Execute(sql,new {Id=id});
                return res > 0;
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}