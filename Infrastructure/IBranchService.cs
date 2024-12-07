using Domain;

namespace Infrastructure;

public interface IBranchService
{
    bool Create(Branch branch);
    List<Branch> GetAll();
    Branch GetById(int id);
    bool Update(Branch branch);
    bool Delete(int id);
}