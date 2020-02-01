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
    [Dapper.Contrib.Extensions.Table("[User]")]
    public class User
    {
        [Dapper.Contrib.Extensions.Key]
        public long userid { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }

    public class UserDac : BaseDac
    {

        public const string SqlTableName = "User";
        public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName + " ";



        public UserDac()
        {
        }

        public UserDac(string ConnectionString)
        {
            Connection = ConnectionFactory.createConnection(ConnectionString);
        }

        public UserDac(IDbConnection connection)
        {
            Connection = connection;
        }

        public UserDac(IDbTransaction transaction)
        {
            Transaction = transaction;
            Connection = transaction.Connection;
        }

        public UserDac(BaseDac dapProvider)
        {
            Transaction = dapProvider.Transaction;
            Connection = dapProvider.Connection;
        }

        public User Get(long id)
        {
            var user = Connection.Get<User>(id);
            return user;
        }

        public User GetByMobile(string mobile)
        {
            var userlist = Connection.QueryFirst<User>(SqlSelectCommand + " WHERE mobile=@mobile", new { mobile = mobile });
            return userlist;
        }

        public User GetByEmail(string eMail)
        {
            var userlist = Connection.QueryFirst<User>(SqlSelectCommand + " WHERE eMail=@eMail", new { eMail = eMail });
            return userlist;
        }

        public User GetByLogin(string login)
        {
            var user = Connection.QueryFirst<User>(SqlSelectCommand + " WHERE login=@login", new { login = login });
            return user;
        }

        public List<User> GetLikeByLastName(string lastname)
        {
            var userlist = Connection.Query<User>(SqlSelectCommand + " WHERE lastname like @lastname", new { lastname = lastname }).AsList();
            return userlist;
        }


        public long Insert(User user)
        {
            var identity = Connection.Insert<User>(user);
            return identity;
        }


        public bool Update(User user)
        {
            var isSuccess = Connection.Update<User>(user);
            return isSuccess;
        }

        public bool Delete(User user)
        {
            var isSuccess = Connection.Delete<User>(user);
            return isSuccess;
        }

        public bool Register(User user)
        {
            PasswordHasher<string> pw = new PasswordHasher<string>();
            string hashedpass = pw.HashPassword(user.login, user.password);
            user.password = hashedpass;
            try
            {
                var identity = Connection.Insert<User>(user);
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }


        public User Authenticate(string Login, string nonHasheddPassword)
        {
            var user = GetByLogin(Login);
            if (user.password == nonHasheddPassword)
            {
                return user;
            }
            return null;
        }

    }
}
