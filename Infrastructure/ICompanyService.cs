namespace Infrastructure;

public interface ICompanyService
{
    bool Create(Company company);
    List<Company> GetAll();
    Company GetById(int id);
    bool Update(Company company);
    bool Delete(int id);
}