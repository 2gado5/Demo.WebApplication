using B1.Demo.WebApplication.Common.Entities;
using B1.Demo.WebApplication.Common.Entities.DTO;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WebApplication.DL.BaseDL
{
    public class BaseDL<T> : IBaseDL<T>
    {
        #region Method
        public List<T> Query(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.Query<T>(sql, param, transaction, true, commandTimeout, commandType).ToList();
        }

        public T QueryFirstOrDefault(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public IDbConnection GetOpenConnection()
        {
            var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);
            mySqlConnection.Open();
            return mySqlConnection;
        }

        public T GetRecordById(Guid recordId)
        {
            // cbi tên Stored
            string storedProcedureName = $"Proc_{typeof(T).Name}_GetByID";

            // chuẩn bị tham số đầu vào 
            var parameters = new DynamicParameters();
            parameters.Add($"v_{typeof(T).Name}ID", recordId);

            //  khởi tạo kết nối vs DB
            var dbConnection = GetOpenConnection();

            // Thực hiện câu lệnh SQL
            var record = QueryFirstOrDefault(dbConnection, storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            dbConnection.Close();

            return record;
        }

        public List<T> GetRecords()
        {
            string storedProcedureName = $"Proc_{typeof(T).Name}_GetAll";

            var parameters = new DynamicParameters();

            var dbConnection = GetOpenConnection();

            var record = Query(dbConnection, storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            dbConnection.Close();

            return record;
        }

        public int InsertRecord(T record)
        {
            throw new NotImplementedException();
        }

        public int UpdateRecord(Guid ID, T record)
        {
            throw new NotImplementedException();
        }

        public int DeleteRecord(Guid recordId)
        {
            throw new NotImplementedException();
        }

        public PagingResult<T> GetPaging(string? keyword, Guid? departmantId, Guid? positionId, int pageSize = 10, int pageNumber = 1)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
