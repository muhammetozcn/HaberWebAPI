using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
      
        
        [Route("GetData/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetData(int id = 0)
        {// http://localhost:12386/api/values/
            try
            {
                SqlConnection connect;
                connect = new SqlConnection();
                connect.ConnectionString = "Data Source=DESKTOP-TEFQ6AA\\MSSQL;Initial Catalog=yazlab02;User Id=sa;Password=1";
                connect.Open();
                string sorgu = "SELECT * FROM haberData where haberID= "+id ;
                SqlCommand komut = new SqlCommand(sorgu, connect);
                SqlDataReader oku = komut.ExecuteReader();
                List<Haber> haberListe = new List<Haber>();

                while (oku.Read())
                {
                   
                    Haber temp = new Haber();
                    temp.haberID = int.Parse(oku["haberID"].ToString());
                    temp.haberTuru = oku["haberTuru"].ToString();
                    temp.yayinTarih = Convert.ToDateTime((oku["yayinTarih"].ToString()));//dd.MM.yyyy yaparsın 
                    temp.haberResim = oku["haberResim"].ToString();
                    temp.haberBaslik = oku["haberBaslik"].ToString();
                    temp.haberIcerik = oku["haberIcerik"].ToString();
                    temp.haberLike = int.Parse(oku["HaberLike"].ToString());
                    temp.haberDislike = int.Parse(oku["HaberDislike"].ToString());
                    temp.haberView = int.Parse(oku["haberView"].ToString());
                    haberListe.Add(temp);
                }
                return Ok(haberListe);

            }
            catch (Exception ex)

            {
                return InternalServerError(ex);
            }
          
        }

        [Route("GetAll")]//Hepsini döndürür
        [HttpGet]
        public IHttpActionResult GetCategory()//default değerler kod patlamasın diye koyulur
        {// http://localhost:12386/api/values/

            //yapalım.
            SqlConnection connect;
            connect = new SqlConnection();
            connect.ConnectionString = "Data Source=DESKTOP-TEFQ6AA\\MSSQL;Initial Catalog=yazlab02;User Id=sa;Password=1";
            connect.Open();
            string sorgu = "SELECT * FROM haberData   ";
            SqlCommand komut = new SqlCommand(sorgu, connect);
            SqlDataReader oku = komut.ExecuteReader();
            List<Haber> haberListe = new List<Haber>();
            while (oku.Read())
            {
                //dogry mu? eksık varsa ekle
                //databaseye gerek yok burda problem yok
                Haber temp = new Haber();
                temp.haberID = int.Parse(oku["haberID"].ToString());
                temp.haberTuru = oku["haberTuru"].ToString();
                temp.yayinTarih = DateTime.Parse(oku["yayinTarih"].ToString());//dd.MM.yyyy yaparsın sonra saat istersen HH:mm
                temp.haberResim = oku["haberResim"].ToString();
                temp.haberBaslik = oku["haberBaslik"].ToString();
                temp.haberIcerik = oku["haberIcerik"].ToString();
                temp.haberLike = int.Parse(oku["HaberLike"].ToString());
                temp.haberDislike = int.Parse(oku["HaberDislike"].ToString());
                temp.haberView = int.Parse(oku["haberView"].ToString());
                haberListe.Add(temp);
            }
            //var response = Request.CreateResponse(HttpStatusCode.OK, haberListe);
            return Ok(haberListe);
        }




       
        }


       
    }
}
