using Domain;
using Infrastructure;
using Npgsql;
using Dapper;
namespace Application;

public class DeparmentService: IDepartmentService
{
    public bool Create(Department department)
    {
        try
        { 
            using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
            { 
                var sql = "insert into department(name, companyid) values (@Name, @CompanyId);";
                var res = connection.Execute(sql,department);
                return res > 0;
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public List<Department> GetAll()
    {
        try
        {
         using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
         {
            var sql = "select * from department";
            var res = connection.Query<Department>(sql).ToList();
            return res;
         }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public Department GetById(int id)
    {
        try
        {
         using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
         {
            var sql = "select * from department where id=@Id";
            var res = connection.QuerySingle<Department>(sql,new {Id=id});
            return res;
         }   

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Update(Department department)
    {
        try
        {
         using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
         {
            var sql = "update department set name=@Name,companyid=@CompanyId where id=@Id;";
            var res = connection.Execute(sql,department);
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
            var sql = "delete from department where id=@Id";
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