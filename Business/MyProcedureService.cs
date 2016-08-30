using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MyProcedureService
    {
        #region ReadOnly

        private readonly GenericRepository<MyProcedure_Result> _myProcRepo;
        private WebAPI_ModelContainer _context;

        #endregion

        #region Constructor
        public MyProcedureService()
        {
            _context = new WebAPI_ModelContainer();
            _myProcRepo = new GenericRepository<MyProcedure_Result>(_context);
        }

        #endregion

        #region Item

        public IEnumerable<MyProcedure_Result> GetWithRawSqlService(int ID, string FName)
        {
            var myProc = _myProcRepo.GetWithRawSql(ID, FName).ToList();
            return myProc;
        }

        #endregion
    }
}
