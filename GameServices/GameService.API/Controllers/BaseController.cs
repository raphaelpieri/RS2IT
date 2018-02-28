using System.Threading.Tasks;
using GameService.Shared.Commands;
using GameServices.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace GameService.API.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult> Response(ICommandResult result)
        {
            if(result.Sucess)
                _unitOfWork.Commit();

            return result;
        }
    }
}