using B1.Demo.WebApplication.Common.Entities.DTO;
using B1.Demo.WebApplication.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WebApplication.BL.BaseBL
{
    public interface IBaseBL<T>
    {
        public List<T> GetRecords();

        public T GetRecordById(Guid recordId);

        public PagingResult<T> GetPaging(
           string? keyword,
           Guid? departmantId,
           Guid? positionId,
           int pageSize = 10,
           int pageNumber = 1);
    }
}
