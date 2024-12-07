using Domain;
using Infrastructure;
using Npgsql;
using Dapper;
namespace Application;

public class BranchService : IBranchService
{
    public bool Create(Branch branch)
    {
        try
        {
         using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
         {
            var sql = "insert into branch(name, departmentid) VALUES (@Name, @DepartmentId);";
            var res = connection.Execute(sql,branch);
            return res > 0;
         }   

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public List<Branch> GetAll()
    {
        try
        {
         using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
         {
            var sql = "select * from branch";
            var res = connection.Query<Branch>(sql).ToList();
            return res;
         }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public Branch GetById(int id)
    {
        try
        {
         using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
         {
            var sql = "select * from branch where id=@Id";
            var res = connection.QuerySingle<Branch>(sql,new {Id=id});
            return res;
         } 

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Update(Branch branch)
    {
        try
        {
         using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
         {
            var sql = "update branch set name=@Name,departmentid=@DepartmentId where id=@Id;";
            var res = connection.Execute(sql,branch);
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
            var sql = "delete from branch where id=@Id";
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