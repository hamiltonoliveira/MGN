using System.Threading.Tasks;

namespace Applicationcore.UnitOfWork
{
    public  interface IUnitOfWork
    {
        Task SalvarBco();
    }
}
