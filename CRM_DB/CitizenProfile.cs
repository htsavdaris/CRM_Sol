using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Identity;

namespace CRM_DB
{
    [Dapper.Contrib.Extensions.Table("CitizenProfile")]
    public class CitizenProfile
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public long userid { get; set; }
        public string amka { get; set; }
        public string afm { get; set; }
        public string fathername { get; set; }
        public string mothername { get; set; }
        public System.DateTime dateofbirth { get; set; }
        public string cityofbirth { get; set; }
        public string telephone { get; set; }
    }

    public class CitizenProfileDac : BaseDac
    {

        public const string SqlTableName = "CitizenProfile";
        public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName + " ";

        public CitizenProfileDac()
        {
        }
        
        public CitizenProfileDac(string ConnectionString)
        {
            Connection = ConnectionFactory.createConnection(ConnectionString);
        }

        public CitizenProfileDac(IDbConnection connection)
        {
            Connection = connection;            
        }

        public CitizenProfileDac(IDbTransaction transaction)
        {
            Transaction = transaction;
            Connection = transaction.Connection;
        }

        public CitizenProfileDac(BaseDac dapProvider)
        {
            Transaction = dapProvider.Transaction;
            Connection = dapProvider.Connection;
        }

        public CitizenProfile Get(long id)
        {
            var citizen = Connection.Get<CitizenProfile>(id);
            return citizen;                
        }

        public List<CitizenProfile> GetAll()
        {
            var citizenList = Connection.GetAll<CitizenProfile>().AsList();
            return citizenList;
        }

        public CitizenProfile GetByAFM(string AFM)
        {
            var citizenList = Connection.QueryFirst<CitizenProfile>(SqlSelectCommand + " WHERE AFM=@AFM", new { AFM = AFM });
            return citizenList;
        }

        public CitizenProfile GetByAMKA(string AMKA)
        {
            var citizenList = Connection.QueryFirst<CitizenProfile>(SqlSelectCommand + " WHERE AMKA=@AMKA", new { AMKA = AMKA });
            return citizenList;
        }
        

        public long Insert(CitizenProfile citizen)
        {
            var identity = Connection.Insert<CitizenProfile>(citizen);
            return identity;
        }
        
        
        public bool Update(CitizenProfile citizen)
        {
            var isSuccess = Connection.Update<CitizenProfile>(citizen);
            return isSuccess;
        }

        public bool Delete(CitizenProfile citizen)
        {
            var isSuccess = Connection.Delete<CitizenProfile>(citizen);
            return isSuccess;
        }



    }


}
