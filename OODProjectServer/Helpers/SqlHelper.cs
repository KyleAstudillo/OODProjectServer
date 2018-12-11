using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using OODProjectServer.Entities;

namespace OODProjectServer.Helpers
{
    public class SqlHelper
    {
        string sqlConnectionString = "Server = tcp:oodproject.database.windows.net, 1433; " +
                                                "Initial Catalog = Coffee; " +
                                                "Persist Security Info = False; " +
                                                "User ID = kyle@admin@oodproject.database.windows.net; " +
                                                "Password = #*2C67zCr2uKe4jv; " +
                                                "MultipleActiveResultSets = False; " +
                                                "Encrypt = True; " +
                                                "TrustServerCertificate = False; " +
                                                "Connection Timeout = 30;";
        SqlConnection conn;

        public SqlHelper()
        {
        }

        private SqlDataReader GetSqlDataReader(string sqlString)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = this.sqlConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                sqlDataReader = cmd.ExecuteReader();
                return sqlDataReader;
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
                conn.Close();
                return sqlDataReader;
            }
        }

        //************** Coffee ******************
        //SQL PUTS Coffee
        public int putCoffeeItem(CoffeeItem item)
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.sqlConnectionString;
            string query = "INSERT INTO coffee (id, name, image_1, image_2, userid, coffeeid) VALUES (@Id, @Name, @ImageLink1, @ImageLink2, @UserId, @CoffeeId)";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@ImageLink1", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@ImageLink2", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@UserId", System.Data.SqlDbType.Int);
            command.Parameters.Add("@CoffeeId", System.Data.SqlDbType.Int);

            command.Parameters["@Id"].Value = item.Id;
            command.Parameters["@Name"].Value = item.Name;
            command.Parameters["@ImageLink1"].Value = item.ImageLink1;
            command.Parameters["@ImageLink2"].Value = item.ImageLink2;
            command.Parameters["@UserId"].Value = item.UserId;
            command.Parameters["@CoffeeId"].Value = item.CoffeeId;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            // Check Error
            if (result < 0) {
                Console.WriteLine("Error inserting data into Database!");
                return 1;
            }
            return 0;
        }

        //SQL GETS Coffee
        public List<CoffeeItem> getAllCoffeeItems()
        {
            SqlDataReader sqlDataReader = GetSqlDataReader("SELECT * FROM coffee");
            return readSqlToCoffeeItem(sqlDataReader);
        }

        public List<CoffeeItem> GetCoffeeItemByID(int id)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM coffee WHERE id = {id}");
            return readSqlToCoffeeItem(sqlDataReader);
        }

        public List<CoffeeItem> GetCoffeeItemByName(string name)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM coffee WHERE name = {name}");
            return readSqlToCoffeeItem(sqlDataReader);
        }

        public List<CoffeeItem> GetCoffeeItemByCoffeeID(int id)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM coffee WHERE coffeeid = {id}");
            return readSqlToCoffeeItem(sqlDataReader);
        }

        public List<CoffeeItem> GetCoffeeItemByUserID(int id)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM coffee WHERE userid = {id}");
            return readSqlToCoffeeItem(sqlDataReader);
        }

        //SQL Delete Coffee
        public void DeleteCoffeeItem(CoffeeItem item)
        {
            //TODO
        }

        //************** Inventory ******************
        //SQL PUTS Inventory
        public int putInventoryItem(InventoryItem item)
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.sqlConnectionString;
            string query = "INSERT INTO inventory (id, coffeeid, price, pricebought, locationid, inventorycount) VALUES (@Id, @CoffeeId, @Price, @PriceBought, @LocationId, @InventoryCount)";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            command.Parameters.Add("@CoffeeId", System.Data.SqlDbType.Int);
            command.Parameters.Add("@Price", System.Data.SqlDbType.Money);
            command.Parameters.Add("@PriceBought", System.Data.SqlDbType.Money);
            command.Parameters.Add("@LocationId", System.Data.SqlDbType.Int);
            command.Parameters.Add("@InventoryCount", System.Data.SqlDbType.Int);

            command.Parameters["@Id"].Value = item.Id;
            command.Parameters["@CoffeeId"].Value = item.CoffeeId;
            command.Parameters["@Price"].Value = item.Price;
            command.Parameters["@PriceBought"].Value = item.PriceBought;
            command.Parameters["@LocationId"].Value = item.LocationId;
            command.Parameters["@InventoryCount"].Value = item.InventoryCount;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            // Check Error
            if (result < 0)
            {
                Console.WriteLine("Error inserting data into Database!");
                return 1;
            }
            return 0;
        }

        //SQL GETS Inventory
        public List<InventoryItem> getAllInventoryItems()
        {
            SqlDataReader sqlDataReader = GetSqlDataReader("SELECT * FROM inventory");
            return readSqlToInventoryItem(sqlDataReader);
        }

        public List<InventoryItem> GetInventoryItemByID(int id)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM inventory WHERE id = {id}");
            return readSqlToInventoryItem(sqlDataReader);
        }

        public List<InventoryItem> GetInventoryItemByCoffeeID(int id)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM inventory WHERE coffeeid = {id}");
            return readSqlToInventoryItem(sqlDataReader);
        }

        public List<InventoryItem> GetInventoryItemByLocationID(int id)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM inventory WHERE locationid = {id}");
            return readSqlToInventoryItem(sqlDataReader);
        }
        //SQL Delete Inventory
        public void DeleteInventoryItem(InventoryItem item)
        {
            //TODO
        }

        //*********************** Location *********************
        //SQL PUTS Location
        public int putLocationItem(LocationItem item)
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.sqlConnectionString;
            string query = "INSERT INTO inventory (id, locationid, streetnumber, streetname, city, zipcode) VALUES (@Id, @LocationId, @StreetNumber, @StreetName, @City, @ZipCode)";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            command.Parameters.Add("@LocationId", System.Data.SqlDbType.Int);
            command.Parameters.Add("@StreetNumber", System.Data.SqlDbType.Int);
            command.Parameters.Add("@StreetName", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@City", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@ZipCode", System.Data.SqlDbType.Int);

            command.Parameters["@Id"].Value = item.Id;
            command.Parameters["@LocationId"].Value = item.LocationId;
            command.Parameters["@StreetName"].Value = item.StreetName;
            command.Parameters["@StreetNumber"].Value = item.StreetNumber;
            command.Parameters["@City"].Value = item.City;
            command.Parameters["@ZipCode"].Value = item.ZipCode;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            // Check Error
            if (result < 0)
            {
                Console.WriteLine("Error inserting data into Database!");
                return 1;
            }
            return 0;
        }
        //SQL GETS Location
        public List<LocationItem> getAllLocationItems()
        {
            SqlDataReader sqlDataReader = GetSqlDataReader("SELECT * FROM location");
            return readSqlToLocationItem(sqlDataReader);
        }

        public List<LocationItem> GetLocationItemByID(int id)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM location WHERE id = {id}");
            return readSqlToLocationItem(sqlDataReader);
        }

        public List<LocationItem> GetLocationItemByLocationID(int id)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM location WHERE locationid = {id}");
            return readSqlToLocationItem(sqlDataReader);
        }

        public List<LocationItem> GetLocationItemByCityID(string city)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM location WHERE city = {city}");
            return readSqlToLocationItem(sqlDataReader);
        }
        //SQL Delete Location
        public void DeleteLocationItem(LocationItem item)
        {
            //TODO
        }


        //*********************** User *********************
        //SQL PUTS User
        public int putUserItem(UserItem item)
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.sqlConnectionString;
            string query = "INSERT INTO inventory (id, firstname, lastname, email, datestarted, rank, userid) VALUES (@Id, @FirstName, @LastName, @Email, @DateStarted, @Rank, @UserId)";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            command.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@DateStarted", System.Data.SqlDbType.Date);
            command.Parameters.Add("@Rank", System.Data.SqlDbType.Int);
            command.Parameters.Add("@UserId", System.Data.SqlDbType.Int);

            command.Parameters["@Id"].Value = item.Id;
            command.Parameters["@FirstName"].Value = item.FirstName;
            command.Parameters["@LastName"].Value = item.LastName;
            command.Parameters["@Email"].Value = item.Email;
            command.Parameters["@DateStarted"].Value = item.DateStarted; //TODO Test this
            command.Parameters["@Rank"].Value = item.Rank;
            command.Parameters["@UserId"].Value = item.UserId;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            // Check Error
            if (result < 0)
            {
                Console.WriteLine("Error inserting data into Database!");
                return 1;
            }
            return 0;
        }
        //SQL GETS User
        public List<UserItem> getAllUserItems()
        {
            SqlDataReader sqlDataReader = GetSqlDataReader("SELECT * FROM users");
            return readSqlToUserItem(sqlDataReader);
        }
        public List<UserItem> GetUserItemByID(int id)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM users WHERE id = {id}");
            return readSqlToUserItem(sqlDataReader);
        }

        public List<UserItem> GetUserItemByUserID(int id)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM users WHERE userid = {id}");
            return readSqlToUserItem(sqlDataReader);
        }

        public List<UserItem> GetUserItemByLastNameID(string lastname)
        {
            SqlDataReader sqlDataReader = GetSqlDataReader($"SELECT * FROM users WHERE lastname = {lastname}");
            return readSqlToUserItem(sqlDataReader);
        }
        //SQL Delete User
        public void DeleteUserItem(UserItem item)
        {
            //TODO
        }


        //*************** Helpers *************

        private List<CoffeeItem> readSqlToCoffeeItem(SqlDataReader sqlDataReader)
        {
            List<CoffeeItem> coffeeList = new List<CoffeeItem>();
            try
            {
                while (sqlDataReader.Read())
                {
                    CoffeeItem coffeeItem = new CoffeeItem();
                    coffeeItem.Id = (int)sqlDataReader["id"];
                    try
                    {
                        coffeeItem.Name = (string)sqlDataReader["name"];
                    }
                    catch
                    {
                        coffeeItem.Name = "Null";
                    }
                    try
                    {
                        coffeeItem.ImageLink1 = (string)sqlDataReader["image_1"];
                    }
                    catch
                    {
                        coffeeItem.ImageLink1 = "Null";
                    }
                    try
                    {
                        coffeeItem.ImageLink2 = (string)sqlDataReader["image_2"];
                    }
                    catch
                    {
                        coffeeItem.ImageLink2 = "Null";
                    }
                    coffeeItem.UserId = (int)sqlDataReader["userid"];
                    coffeeItem.CoffeeId = (int)sqlDataReader["coffeeid"];
                    coffeeList.Add(coffeeItem);
                }
            }
            catch (Exception e)
            {
                Debug.Print("***************** KYLELOG: Failed to grab object" + e.ToString());
            }
            conn.Close();
            return coffeeList;
        }

        private List<InventoryItem> readSqlToInventoryItem(SqlDataReader sqlDataReader)
        {
            List<InventoryItem> itemList = new List<InventoryItem>();
            try
            {
                while (sqlDataReader.Read())
                {
                    InventoryItem item = new InventoryItem();
                    item.Id = (int)sqlDataReader["id"];
                    item.CoffeeId = (int)sqlDataReader["coffeeid"];
                    item.Price = (decimal) sqlDataReader["price"];
                    item.PriceBought = (decimal)sqlDataReader["pricebought"];
                    item.LocationId = (int)sqlDataReader["locationid"];
                    item.InventoryCount = (int)sqlDataReader["inventorycount"];
                    itemList.Add(item);
                }
            }
            catch (Exception e)
            {
                Debug.Print("***************** KYLELOG: Failed to grab object" + e.ToString());
            }
            conn.Close();
            return itemList;
        }

        private List<LocationItem> readSqlToLocationItem(SqlDataReader sqlDataReader)
        {
            List<LocationItem> itemList = new List<LocationItem>();
            try
            {
                while (sqlDataReader.Read())
                {
                    LocationItem item = new LocationItem();
                    item.Id = (int)sqlDataReader["id"];
                    item.LocationId = (int)sqlDataReader["locationid"];
                    item.StreetNumber = (int)sqlDataReader["streetnumber"];
                    try
                    {
                        item.StreetName = (string)sqlDataReader["streetname"];
                    }
                    catch
                    {
                        item.StreetName = "Null";
                    }
                    try
                    {
                        item.City = (string)sqlDataReader["city"];
                    }
                    catch
                    {
                        item.City = "Null";
                    }
                    item.ZipCode = (int)sqlDataReader["zipcode"];
                    itemList.Add(item);
                }
            }
            catch (Exception e)
            {
                Debug.Print("***************** KYLELOG: Failed to grab object" + e.ToString());
            }
            conn.Close();
            return itemList;
        }

        private List<UserItem> readSqlToUserItem(SqlDataReader sqlDataReader)
        {
            List<UserItem> itemList = new List<UserItem>();
            try
            {
                while (sqlDataReader.Read())
                {
                    UserItem item = new UserItem();
                    item.Id = (int)sqlDataReader["id"];
                    try
                    {
                        item.FirstName = (string)sqlDataReader["firstname"];
                    }
                    catch
                    {
                        item.FirstName = "Null";
                    }
                    try
                    {
                        item.LastName = (string)sqlDataReader["lastname"];
                    }
                    catch
                    {
                        item.LastName = "Null";
                    }
                    try
                    {
                        item.Email = (string)sqlDataReader["email"];
                    }
                    catch
                    {
                        item.Email = "Null";
                    }
                    item.DateStarted = DateTime.Now;
                    item.Rank = (int)sqlDataReader["id"];
                    item.UserId = (int)sqlDataReader["id"];
                    itemList.Add(item);
                }
            }
            catch (Exception e)
            {
                Debug.Print("***************** KYLELOG: Failed to grab object" + e.ToString());
            }
            conn.Close();
            return itemList;
        }
    }
}
