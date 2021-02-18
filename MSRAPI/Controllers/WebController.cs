using MSR.CORE.Logger;
using MSRDAL.Models;
using MSRDAL.Entities;
//using MSRBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using MSRAPI.WEBBL;

namespace MSRAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/web/{action}")]
    public class WebController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetWebData(int Month,int Year)
        {
            var response = new List<TaskModel>();
            try
            {
                response = await new WebBL().GetWebData(Month,Year);
            }
            catch (Exception ex)
            {
                LogManager.Logger.WriteException("WebController", "GetWebData", ex.Message, ex);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetYearAndMonths()
        {
            var response = new MonthAndYearModel();
            try
            {
                response = await new WebBL().GetYearAndMonths();
            }
            catch (Exception ex)
            {
                LogManager.Logger.WriteException("WebController", "GetYearAndMonths", ex.Message, ex);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetHelpDeskTickets(int Month, int Year)
        {
            var response = new List<HelpDeskTickets>();
            try
            {
                response = await new WebBL().GetHelpDeskTickets(Month,Year);
            }
            catch (Exception ex)
            {
                LogManager.Logger.WriteException("WebController", "GetHelpDeskTickets", ex.Message, ex);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetWebTrendReportData(int Month, int Year)
        {
            var response = new WebTrend();
            try
            {
                response = await new WebBL().GetWebTrendReportData(Month, Year);
            }
            catch (Exception ex)
            {
                LogManager.Logger.WriteException("WebController", "GetWebTrendReportData", ex.Message, ex);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetWebPrivateData(int Month, int Year)
        {
            var response = new List<PrivateTaskModel>();
            try
            {
                response = await new WebBL().GetWebPrivateData(Month, Year);
            }
            catch (Exception ex)
            {
                LogManager.Logger.WriteException("WebController", "GetWebPrivateData", ex.Message, ex);
            }
            return Ok(response);
        }
    }
}
