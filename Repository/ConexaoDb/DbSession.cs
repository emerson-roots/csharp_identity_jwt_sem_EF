using project.Models;
using SQLite;
using System.IO;

namespace project.Repository
{
    public class DbSession
    {

        public readonly SQLiteAsyncConnection Connection;
        private static DbSession _database;
        private static string _diretorioBanco = Path.Combine($"{ Directory.GetCurrentDirectory() }\\Repository\\ConexaoDb", "db_identity_sem_EF.db3");

        public DbSession()
        {
            Connection = new SQLiteAsyncConnection(_diretorioBanco);
            //DropTables();
            CreateTables();
        }

        // Create the database connection as a singleton.
        public DbSession Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new DbSession();
                }
                return _database;
            }
        }

        public void CreateTables()
        {

            string roleTable = @"CREATE TABLE IF NOT EXISTS ApplicationRole (
                                        Id             INTEGER NOT NULL 
                                                            CONSTRAINT PK_Roles PRIMARY KEY AUTOINCREMENT,
                                        Name           TEXT,
                                        NormalizedName TEXT
                                    );
                                    ";

            string userTable = @"CREATE TABLE IF NOT EXISTS ApplicationUser (
                                        Id                   INTEGER NOT NULL 
                                                                     CONSTRAINT PK_Users PRIMARY KEY AUTOINCREMENT,
                                        UserName             TEXT    NOT NULL,
                                        NormalizedUserName   TEXT    NOT NULL,
                                        Email                TEXT,
                                        NormalizedEmail      TEXT,
                                        EmailConfirmed       INTEGER NOT NULL,
                                        PasswordHash         TEXT,
                                        PhoneNumber          TEXT,
                                        PhoneNumberConfirmed INTEGER NOT NULL,
                                        TwoFactorEnabled     INTEGER NOT NULL
                                    );";

            string userRoleTable = @"CREATE TABLE IF NOT EXISTS ApplicationUserRole (
                                                UserId INTEGER NOT NULL,
                                                RoleId INTEGER NOT NULL,
                                                CONSTRAINT PK_UserRoles PRIMARY KEY (
                                                    UserId,
                                                    RoleId
                                                ),
                                                CONSTRAINT FK_UserRoles_Roles_RoleId FOREIGN KEY (
                                                    RoleId
                                                )
                                                REFERENCES ApplicationRole (Id) ON DELETE CASCADE,
                                                CONSTRAINT FK_UserRoles_Users_UserId FOREIGN KEY (
                                                    UserId
                                                )
                                                REFERENCES ApplicationUser (Id) ON DELETE CASCADE
                                            );
                                            ";

           
            Connection.QueryAsync<ApplicationUser>(roleTable).Wait();
            Connection.QueryAsync<ApplicationRole>(userTable).Wait();
            Connection.QueryAsync<ApplicationUserRole>(userRoleTable).Wait();
        }

        public void DropTables()
        {

            Connection.DropTableAsync<ApplicationUserRole>().Wait();
            Connection.DropTableAsync<ApplicationRole>().Wait();
            Connection.DropTableAsync<ApplicationUser>().Wait();
          
        }

    }
}
