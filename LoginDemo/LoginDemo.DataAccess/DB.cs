using Dapper;
using Dapper.Contrib.Extensions;
using LoginDemo.DataModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDemo.DataAccess
{
    public class DB
    {
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["logindemodb"].ConnectionString;

        private static object Lock = new object();

        public static List<User> GetUsers()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<User>("select * from [Users] with(nolock)").ToList();
            }
        }

        public static long AddUser(User user)
        {
            lock (Lock)
            {
                using (var con = new SqlConnection(ConnectionString))
                {
                    return con.Insert<User>(user);
                }
            }
        }

        public static bool UpdateUser(User user)
        {
            lock (Lock)
            {
                using (var con = new SqlConnection(ConnectionString))
                {
                    var userInDB = con.Query<User>("select * from [Users] with(nolock) where username = @username", 
                                                      new { username = user.UserName })
                                      .FirstOrDefault();

                    if (userInDB != null)
                    {
                        if (user.LoginTime != null && user.LoginTime != userInDB.LoginTime)
                            userInDB.LoginTime = user.LoginTime;
                        if (user.LogoffTime != null && user.LogoffTime != userInDB.LogoffTime)
                            userInDB.LogoffTime = user.LogoffTime;
                        if (user.Password != null && user.Password != userInDB.Password)
                            userInDB.Password = user.Password;
                        if (user.UpdateTime != null && user.UpdateTime != userInDB.UpdateTime)
                            userInDB.UpdateTime = user.UpdateTime;
                        if (user.DisplayName != null && user.DisplayName != userInDB.DisplayName)
                            userInDB.DisplayName = user.DisplayName;
                    }
                    return con.Update<User>(userInDB);
                }
            }
        }
    }
}
