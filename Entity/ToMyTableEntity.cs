using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public static class ToMyTableEntity
    {
        public static MyTableEntity _ToMyTableEntity(this MyTable tab)
        {
            var tabEntity = new MyTableEntity()
            {
                MyID = tab.MyID ,
                MyFirstName = tab.MyFirstName ,
                MyLastName = tab.MyLastName ,
                MyGender = tab.MyGender
            };
            return tabEntity;
        }

        public static List<MyTableEntity> _ToMyTableEntity(this List<MyTable> tabList)
        {
            var tabEntityList = new List<MyTableEntity>();
            foreach (var t in tabList)
            {
                tabEntityList.Add(t._ToMyTableEntity());
            }
            return tabEntityList;
        }
    }
}
