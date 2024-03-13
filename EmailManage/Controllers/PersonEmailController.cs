using EmailManage.Data;
using EmailManage.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EmailManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonEmailController : ControllerBase
    {

        private readonly DataContext _dataContext;

        // Конструктор контроллера, принимающий DataContext в качестве зависимости
        public PersonEmailController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Получение всех сообщений
        [HttpGet]
        public async Task<ActionResult<List<EmailPersons>>> GetAllMessages ()
        {
            try
            {
                var persons = await _dataContext.EmailPersons.ToListAsync();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                // Обработка других исключений
                return StatusCode(StatusCodes.Status500InternalServerError, $"Внутренняя ошибка сервера: {ex.Message}");
            }
        }

        // Поиск сообщения по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailPersons>> FindMessage(int id)
        {
            try
            {
                var person = await _dataContext.EmailPersons.FindAsync(id);
                if (person == null)
                    return NotFound("Обращение не найдено");
                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Внутренняя ошибка сервера: {ex.Message}");
            }
        }

        // Добавление нового сообщения
        [HttpPost]
        public async Task<ActionResult<List<EmailPersons>>> AddMessage(EmailPersons emailPersons)
        {
            try
            {
                if (emailPersons == null)
                {
                    return BadRequest("Некорректные данные для создания сообщения");
                }

                _dataContext.EmailPersons.Add(emailPersons);
                await _dataContext.SaveChangesAsync();
                return Ok(await _dataContext.EmailPersons.ToListAsync());
            }
            catch (Exception ex)
            {
                // Обработка других исключений
                return StatusCode(StatusCodes.Status500InternalServerError, $"Внутренняя ошибка сервера: {ex.Message}");
            }
        }

        // Обновление существующего сообщения
        [HttpPut]
        public async Task<ActionResult<EmailPersons>> PutMessage(EmailPersons updatePersons)
        {
            try
            {
                var findperson = await _dataContext.EmailPersons.FindAsync(updatePersons.Id);
                if (findperson == null)
                    return NotFound("Обращение не найдено");

                // Обновление полей существующего сообщения
                findperson.Title = updatePersons.Title;
                findperson.DateSent = updatePersons.DateSent;
                findperson.Recipient = updatePersons.Recipient;
                findperson.Sender = updatePersons.Sender;
                findperson.Content = updatePersons.Content;
                await _dataContext.SaveChangesAsync();

                return Ok(findperson);
            }
            catch (Exception ex)
            {
                // Обработка других исключений
                return StatusCode(StatusCodes.Status500InternalServerError, $"Внутренняя ошибка сервера: {ex.Message}");
            }
        }

        // Удаление сообщения по ID
        [HttpDelete]
        public async Task<ActionResult<EmailPersons>> DeleteMessage(int id)
        {
            var findperson = await _dataContext.EmailPersons.FindAsync(id);
            if (findperson == null)
                return NotFound("Обращение не найдено");

            _dataContext.EmailPersons.Remove(findperson);
            await _dataContext.SaveChangesAsync();

            return Ok(findperson);
        }
    }
}
