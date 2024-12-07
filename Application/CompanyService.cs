using Infrastructure;

using Npgsql;
using Dapper;
namespace Application;

public class CompanyService: ICompanyService
{
    public bool Create(Company company)
    {
        try
        {
         using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
         {
            var sql = "insert into company(name)values (@Name);";
            var res = connection.Execute(sql,company);
            return res > 0;
         }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public List<Company> GetAll()
    {
        try
        {
         using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
         {
            var sql = "select * from company";
            var res = connection.Query<Company>(sql).ToList();
            return res;
         }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        
    }

    public Company GetById(int id)
    {
        try
        {
         using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
         {
            var sql = "select * from company where id=@Id";
            var res = connection.QuerySingle<Company>(sql,new {Id=id});
            return res;
         }    

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Update(Company company)
    {
        try
        {
         using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.mainConnection))
         {
            var sql = "update company set name=@Name where id=@Id;";
            var res = connection.Execute(sql,company);
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
            var sql = "delete from company where id=@Id";
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