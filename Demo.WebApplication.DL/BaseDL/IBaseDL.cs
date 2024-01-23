using B1.Demo.WebApplication.Common.Entities.DTO;
using B1.Demo.WebApplication.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WebApplication.DL.BaseDL
{
    public interface IBaseDL<T>
    {
        public IDbConnection GetOpenConnection();

        public T QueryFirstOrDefault(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        public List<T> Query(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        public List<T> GetRecords();

        public T GetRecordById(Guid recordId);

        public int InsertRecord(T record);

        public int UpdateRecord(Guid ID, T record);

        public int DeleteRecord(Guid recordId);

        public PagingResult<T> GetPaging(
           string? keyword,
           Guid? departmantId,
           Guid? positionId,
           int pageSize = 10,
           int pageNumber = 1);
    }
}
