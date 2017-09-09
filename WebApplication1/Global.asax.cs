using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DapperExtensions.Sql;
using StackExchange.Profiling;

namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var t = DapperExtensions.DapperExtensions.SqlDialect;
            DapperExtensions.DapperExtensions.SqlDialect = new OracleDialect();
        }

        protected void Application_BeginRequest()
        {
            MiniProfiler.Start();
        }
        protected void Application_EndRequest()
        {
            // not production code!
            MiniProfiler.Stop();
            var logger = NLog.LogManager.GetCurrentClassLogger();
            var instance = MiniProfiler.Current;
            logger.Debug(MiniProfiler.RenderIncludes());
        }
    }
}
