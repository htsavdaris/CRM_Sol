using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace CRM_DB
{
    [Dapper.Contrib.Extensions.Table("Foreas")]
    public class Foreas
    {
        [Dapper.Contrib.Extensions.Key]
        public long ForeasID { get; set; }
        public string ForeasNameShort { get; set; }
        public string ForeasNameLong { get; set; }
        public string ForeasTreeCode { get; set; }
    }

    public class ForeasDac : BaseDac
    {

        public const string SqlTableName = "Foreas";
        public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName + " ";

        public ForeasDac()
        {
        }

        public ForeasDac(string ConnectionString)
        {
            Connection = ConnectionFactory.createConnection(ConnectionString);
        }

        public ForeasDac(IDbConnection connection)
        {
            Connection = connection;
        }

        public ForeasDac(IDbTransaction transaction)
        {
            Transaction = transaction;
            Connection = transaction.Connection;
        }

        public ForeasDac(BaseDac dapProvider)
        {
            Transaction = dapProvider.Transaction;
            Connection = dapProvider.Connection;
        }

        public Foreas Get(long id)
        {
            var citizen = Connection.Get<Foreas>(id);
            return citizen;
        }

        public List<Foreas> GetAll()
        {
            var citizenList = Connection.GetAll<Foreas>().AsList();
            return citizenList;
        }

        public List<Foreas> GetByTreeCode(string ForeasTreeCode)
        {
            var foreasList = Connection.Query<Foreas>(SqlSelectCommand + " WHERE ForeasTreeCode=@ForeasTreeCode ORDERBY ForeasTreeCode", new { ForeasTreeCode = ForeasTreeCode }).AsList();
            return foreasList;
        }

       
       
        public long Insert(Foreas foreas)
        {
            var identity = Connection.Insert<Foreas>(foreas);
            return identity;
        }

        public bool Update(Foreas foreas)
        {
            var isSuccess = Connection.Update<Foreas>(foreas);
            return isSuccess;
        }

        public bool Delete(Foreas foreas)
        {
            var isSuccess = Connection.Delete<Foreas>(foreas);
            return isSuccess;
        }



    }

}
