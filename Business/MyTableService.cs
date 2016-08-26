using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MyTableService
    {
        #region ReadOnly

        private readonly GenericRepository<MyTable> _myTableRepo;
        private WebAPI_ModelContainer _context;

        #endregion

        #region Constructor
        public MyTableService()
        {
            _context = new WebAPI_ModelContainer();
            _myTableRepo = new GenericRepository<MyTable>(_context);
        }

        #endregion

        #region Item
        public IEnumerable<MyTableEntity> GetAllMyTables()
        {
            var myTables = _myTableRepo.GetAll().ToList();
            return myTables._ToMyTableEntity();
        }

        #endregion
    }
}
