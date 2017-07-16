using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using KubeVote.Models;

namespace KubeVote.Controllers
{
    public class VotesController : Controller
    {
        ILogger<VotesController> _logger;
        IDatabase _database;
        public VotesController(IDatabase database, ILogger<VotesController> logger)
        {
            _database = database;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                HashEntry[] items = _database.HashGetAll("Votes");
                var votes = items.Select((item) => new Vote() { Server = item.Name, Count = (long)item.Value });
                _logger.LogInformation("Index..");
                return Ok(votes);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.ToString());
                return base.StatusCode(500, exception);
            }
        }

        [HttpPost]
        [Route("/Votes")]
        public IActionResult AddVote()
        {
            try
            {
                string machineName = System.Environment.MachineName;
                long count = _database.HashIncrement("Votes", machineName);
                _logger.LogInformation($"Votes for {machineName}: {count}");
                return Ok(new Vote() { Server = machineName, Count = count });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.ToString());
                return base.StatusCode(500, exception);
            }

        }
    }
}
