using System;

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

    [Dapper.Contrib.Extensions.Table("Interaction")]
    public class Interaction
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public long InteractionID { get; set; }
        public long CitizenID { get; set; }
        public long ForeasID { get; set; }
        public System.DateTime Date { get; set; }
    }
}
