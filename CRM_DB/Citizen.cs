using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace CRM_DB
{
    [Dapper.Contrib.Extensions.Table("Citizen")]
    public class Citizen
    {
        [Dapper.Contrib.Extensions.Key]
        public long CitizenID { get; set; }
        public string AMKA { get; set; }
        public string AFM { get; set; }
        public string Onoma { get; set; }
        public string Eponimo { get; set; }
        public string Patronimo { get; set; }
        public string Mitronimo { get; set; }
        public System.DateTime HmerominiaGenisis { get; set; }
        public string PoliGenisis { get; set; }
        public string Tilefono { get; set; }
        public string Kinito { get; set; }
        public string eMail { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }

    public class CitizenDac : BaseDac
    {

        public const string SqlTableName = "Citizen";
        public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName + " ";

        public CitizenDac()
        {
        }
        
        public CitizenDac(string ConnectionString)
        {
            Connection = ConnectionFactory.createConnection(ConnectionString);
        }

        public CitizenDac(IDbConnection connection)
        {
            Connection = connection;            
        }

        public CitizenDac(IDbTransaction transaction)
        {
            Transaction = transaction;
            Connection = transaction.Connection;
        }

        public CitizenDac(BaseDac dapProvider)
        {
            Transaction = dapProvider.Transaction;
            Connection = dapProvider.Connection;
        }

        public Citizen Get(long id)
        {
            var citizen = Connection.Get<Citizen>(id);
            return citizen;                
        }

        public List<Citizen> GetAll()
        {
            var citizenList = Connection.GetAll<Citizen>().AsList();
            return citizenList;
        }

        public Citizen GetByAFM(string AFM)
        {
            var citizenList = Connection.QueryFirst<Citizen>(SqlSelectCommand + " WHERE AFM=@AFM", new { AFM = AFM });
            return citizenList;
        }

        public Citizen GetByAMKA(string AMKA)
        {
            var citizenList = Connection.QueryFirst<Citizen>(SqlSelectCommand + " WHERE AMKA=@AMKA", new { AMKA = AMKA });
            return citizenList;
        }
        public Citizen GetByKinito(string Kinito)
        {
            var citizenList = Connection.QueryFirst<Citizen>(SqlSelectCommand + " WHERE Kinito=@Kinito", new { Kinito = Kinito });
            return citizenList;
        }

        public Citizen GetByEmail(string eMail)
        {
            var citizenList = Connection.QueryFirst<Citizen>(SqlSelectCommand + " WHERE eMail=@eMail", new { eMail = eMail });
            return citizenList;
        }

        public Citizen GetByLogin(string login)
        {
            var citizenList = Connection.QueryFirst<Citizen>(SqlSelectCommand + " WHERE login=@login", new { login = login });
            return citizenList;
        }

        public List<Citizen> GetLikeByEponimo(string Eponimo)
        {
            var citizenList = Connection.Query<Citizen>(SqlSelectCommand + " WHERE Eponimo like @Eponimo", new { Eponimo = Eponimo }).AsList();
            return citizenList;
        }

        public long Insert(Citizen citizen)
        {
            var identity = Connection.Insert<Citizen>(citizen);
            return identity;
        }

        public bool Update(Citizen citizen)
        {
            var isSuccess = Connection.Update<Citizen>(citizen);
            return isSuccess;
        }

        public bool Delete(Citizen citizen)
        {
            var isSuccess = Connection.Delete<Citizen>(citizen);
            return isSuccess;
        }



    }


}
