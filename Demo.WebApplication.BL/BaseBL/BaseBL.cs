using B1.Demo.WebApplication.Common.Entities.DTO;
using Demo.WebApplication.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WebApplication.BL.BaseBL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field
        private IBaseDL<T> _baseDL;
        #endregion

        #region Contructor
        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }
        #endregion

        #region Method
        public T GetRecordById(Guid recordId)
        {
            return _baseDL.GetRecordById(recordId);
        }

        public List<T> GetRecords()
        {
            return _baseDL.GetRecords();
        }

        public PagingResult<T> GetPaging(string? keyword, Guid? departmantId, Guid? positionId, int pageSize = 10, int pageNumber = 1)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
