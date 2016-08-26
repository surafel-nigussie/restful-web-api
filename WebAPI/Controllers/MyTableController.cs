using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace WebAPI.Controllers
{
    public class MyTableController : ApiController
    {
        private readonly MyTableService _myTableService;

        public MyTableController()
        {
            _myTableService = new MyTableService();
        }

        [HttpGet]
        public IHttpActionResult GetAllMyTables()
        {
            var tab = _myTableService.GetAllMyTables().ToList();
            return Ok(tab);
        }
	}
}