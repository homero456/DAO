using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SQLServer
{
    public class ModelDAL
    {
        public static DataSet GetBooks()
        {
            SqlConnection con = new SqlConnection(DataBase.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("getbooks", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds, "books");
            return ds;
        }

        public static Book GetBook(int bookid)
        {
            SqlConnection con = new SqlConnection(DataBase.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getbook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookid", bookid);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Book b = new Book();
                    b.Title = dr["title"].ToString();
                    b.Authors = dr["authors"].ToString();
                    b.Price = Double.Parse(dr["price"].ToString());
                    b.Publishers = dr["publisher"].ToString();
                    return b;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public static string AddBook(string title, string authors, double price, string publisher)
        {
            SqlConnection con = new SqlConnection(DataBase.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("addbook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@authors", authors);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@publisher", publisher);
                cmd.ExecuteNonQuery();
                return null; // success 
            }
            catch (Exception ex)
            {
                return ex.Message;  // return error message
            }
            finally
            {
                con.Close();
            }
        }
        public static string DeleteBook(int bookid)
        {
            SqlConnection con = new SqlConnection(DataBase.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("deletebook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookid", bookid);
                cmd.ExecuteNonQuery();
                return null; // success 
            }
            catch (Exception ex)
            {
                return ex.Message;  // return error message
            }
            finally
            {
                con.Close();
            }
        }
        public static string UpdateBook(int bookid, string title, string authors, double price, string publisher)
        {
            SqlConnection con = new SqlConnection(DataBase.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updatebook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookid", bookid);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@authors", authors);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@publisher", publisher);
                cmd.ExecuteNonQuery();
                return null; // success 
            }
            catch (Exception ex)
            {
                return ex.Message;  // return error message
            }
            finally
            {
                con.Close();
            }
        }
    }
}
