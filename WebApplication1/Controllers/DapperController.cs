using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web.Http;
using DapperExtensions;
using Oracle.DataAccess.Client;
using StackExchange.Profiling;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Dapper")]
    public class DapperController : ApiController
    {
        [HttpGet]
        [Route("EventTypes/{eventTypeId}")]
        public IHttpActionResult GetEventType(int eventTypeId)
        {
            var cn = GetConnection();
            var profiler = MiniProfiler.Current;
            EventType result;
            using (profiler.Step("Perform Get Query"))
            {
                result = cn.Get<EventType>(10);
            }            
            return Ok(result);
        }

        [HttpGet]
        [Route("EventTypes")]
        public IHttpActionResult GetEventTypes()
        {
            var cn = GetConnection();
            var profiler = MiniProfiler.Current;
            List<EventType> result;
            using (profiler.Step("Perform GetList Query"))
            {
                result = cn.GetList<EventType>().ToList();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("EventTypes")]
        public IHttpActionResult AddEventTypes(EventType eventType)
        {
            var cn = GetConnection();
            var profiler = MiniProfiler.Current;
            using (profiler.Step("Perform Insert Query"))
            {
                cn.Insert(eventType);
            }
            return Ok(eventType);
        }

        private DbConnection GetConnection()
        {
            var cnn = new OracleConnection(ConfigurationManager.ConnectionStrings["ormDapper"].ConnectionString); // A SqlConnection, SqliteConnection ... or whatever
            // wrap the connection with a profiling connection that tracks timings 
            return new StackExchange.Profiling.Data.ProfiledDbConnection(cnn, MiniProfiler.Current);
        }
    }
}
