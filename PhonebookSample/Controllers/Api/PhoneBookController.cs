using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhonebookSample.Models;
using PhonebookSample.Models.DataModels;
using PhonebookSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookSample.Controllers.Api
{
    [ApiController, Route("api/[controller]")]
    public class PhonebookController : Controller
    {
        private readonly IDataService _dataService;
        private readonly ILogger<PhonebookController> _logger;

        public PhonebookController(IDataService dataService, ILogger<PhonebookController> logger)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var phonebooks = await _dataService.GetAll();

                var phonebooksVm = phonebooks.OrderBy(p => p.Name).GroupBy(p => p.Name.ToUpper()[0], (index, contacts) => new PhoneBookViewModel
                {
                    Index = index,
                    Contacts = contacts
                }).ToList();

                return Ok(phonebooksVm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Data retrieval failure.");
                throw ex;
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                return Ok(await _dataService.GetEntriesByName(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Data retrieval failure.");
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _dataService.GetEntriesById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Data retrieval failure.");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PhoneBook phonebook)
        {
            try
            {
                await _dataService.AddPhonebook(phonebook);
                return await Get();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to add data");
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Entry entry)
        {
            try
            {
                await _dataService.AddPhonebookEntry(entry);
                return await Get(entry.PhoneBookId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to add data");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
