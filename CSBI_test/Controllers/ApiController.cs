using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSBI_test.Areas.Identity.Data;
using CSBI_test.Data;
using CSBI_test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSBI_test.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ApiController : ControllerBase
    {
        ApplicationDbContext _context;
        public ApiController(ApplicationDbContext manager)
        {
            _context = manager;
        }

        // GET: api/Api/GetManagers
        [HttpGet]
        public IEnumerable<Manager> GetManagers()
        {
            return _context.Users.ToList();
        }

        // POST: api/Api/SetTaskToManager/5
        [HttpPost("{taskid}")]
        public async Task<int> SetTaskToManager([FromBody] Manager manager, int taskid)
        {
            try
            {
                var selectedManager = _context.Users.Find(manager.Id);
                _context.Task.FirstOrDefault(x => x.Id == taskid).DelegatedManager = selectedManager;
                await _context.SaveChangesAsync();

                return 0;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }


        // POST: api/Api/CloseMyTask/5
        [HttpPost("{taskId}")]
        public async Task<int> CloseMyTask(int taskId)
        {
            try
            {
                var requestedManager = _context.Users.FirstOrDefault(x => x.Email == ControllerContext.HttpContext.User.Identity.Name);
                var requestedTask = _context.Task.FirstOrDefault(x => x.Id == taskId);
                //если пользователь именно тот, кому назначена эта задача, то изменяем статус задачи
                if (requestedManager == requestedTask.DelegatedManager)
                {
                    requestedTask.ActivityStatus = "Задача завершена";
                    await _context.SaveChangesAsync();
                }
                               
                return 0;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

    }
}
