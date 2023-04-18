using BudgetManagement.Models;
using BudgetManagement.Services;
using Dapper;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BudgetManagement.Controllers
{
    public class TypeAccountController : Controller
    {
        private readonly ITypeAccountRepository _repository;
        private readonly IUserService _userService;

        public TypeAccountController(ITypeAccountRepository repository, IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userService.GetUserId();
            var typeAccount = await _repository.GetTypesAccount(userId);
            return View(typeAccount);
        }

        public IActionResult FormAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(TypeAccountModel typeAccountModel)
        {
            if(!ModelState.IsValid) //
            {
                return View("FormAccount", typeAccountModel); //para mandar el modelo incompleto
            }
            typeAccountModel.UserId = _userService.GetUserId();
            var exists = await _repository.ExistsAccount(typeAccountModel.Name, typeAccountModel.UserId);
            if (exists)
            {
                ModelState.AddModelError(nameof(typeAccountModel.Name),
                    $"El nombre {typeAccountModel.Name} ya existe...");
                return View("FormAccount", typeAccountModel);
            }
            await _repository.CreateAccount(typeAccountModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> VerifyExistenceTypeAccount(String name)
        {
            var userId = _userService.GetUserId();
            var existTypeAccount = await _repository.ExistsAccount(name, userId);

            if(existTypeAccount)
                return Json($"El nombre {name} ya existe");
            return Json(true);
        }

        [HttpGet]
        public async Task<IActionResult> FormUpdateTypeAccount(int id)
        {
            var userId = _userService.GetUserId();
            var typeAccount = await _repository.GetTypeAccount(id, userId);

            if (typeAccount is null)
                return RedirectToAction("NotFound", "Home");
            return View(typeAccount);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTypeAccount(TypeAccountModel typeAccountModel)
        {
            var userId = _userService.GetUserId();
            var typeAccount = await _repository.GetTypeAccount(typeAccountModel.Id, userId);
            if (typeAccount is null)
                return RedirectToAction("NotFound", "Home");
            await _repository.UpdateTypesAccount(typeAccountModel);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = _userService.GetUserId();
            var typeAccount = await _repository.GetTypeAccount(id, userId);

            if(typeAccount is null)
                return RedirectToAction("NotFound", "Home");

            return View(typeAccount);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTypeAccount(int id)
        {
            var userId = _userService.GetUserId();
            var typeAccount = await _repository.GetTypeAccount(id, userId);

            if (typeAccount is null)
                return RedirectToAction("NotFound", "Home");
            await _repository.DeleteTypeAccount(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> OrderTypesAccount([FromBody] int[] ids)
        {
            var userId = _userService.GetUserId();
            var typesAccounts = await _repository.GetTypesAccount(userId);
            var idsTypeAccount = typesAccounts.Select(x => x.Id);

            var idsTiposCuentasNoPertenecenAlUsuario = ids.Except(idsTypeAccount).ToList();

            if(idsTiposCuentasNoPertenecenAlUsuario.Count > 0)
            {
                return Forbid();
            }

            var tiposCuentasOrdenados = ids.Select((valor, index) =>
                new TypeAccountModel() { Id = valor, Orden = index });

            await _repository.OrderTypeAccount(tiposCuentasOrdenados);
            return Ok();
        }
    }
}
