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
        private readonly MyProcedureService _myProcedureService;

        #region Contructor

        public MyTableController()
        {
            _myTableService = new MyTableService();
            _myProcedureService = new MyProcedureService();
        }

        #endregion

        #region Methods

        [HttpGet]
        public IHttpActionResult GetAllFromTables()
        {
            var tab = _myTableService.GetAllMyTables().ToList();
            return Ok(tab);
        }

        [HttpGet]
        public IHttpActionResult GetFromTableByID(int ID)
        {
            var tab = _myTableService.GetMyTableByID(ID).ToList();
            return Ok(tab);
        }

        [HttpGet]
        public IHttpActionResult GetFromProcudureByID(int ID, string FName)
        {
            var tab = _myProcedureService.GetWithRawSqlService(ID, FName).ToList();
            return Ok(tab);
        }

        #endregion
    }
}