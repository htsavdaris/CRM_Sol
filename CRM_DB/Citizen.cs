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
        public CitizenDac()
        {
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

    }


}
