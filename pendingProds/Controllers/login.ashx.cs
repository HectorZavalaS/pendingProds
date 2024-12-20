using pendingProds.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for login
    /// </summary>
    public class login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string json = "{";

            try
            {

                string user_web = context.Request.Form["user"];
                string password = context.Request.Form["password"];
                CSimosUser user = new CSimosUser();
                bool result = false;

                result = SignInSimosDB(user_web, password, ref user);
                CCogiscanCGS db = new CCogiscanCGS();
                //if (result)
                //{
                //    if (context.Request.Cookies["_SUser"] != null)
                //    {
                //        HttpCookie nameCookie = context.Request.Cookies["_SUser"];
                //        nameCookie.Expires = DateTime.Now.AddDays(-1);
                //        context.Response.Cookies.Add(nameCookie);
                //        nameCookie = new HttpCookie("_Slvl");
                //        nameCookie.Expires = DateTime.Now.AddDays(-1);
                //        context.Response.Cookies.Add(nameCookie);
                //    }
                //    else
                //    {
                //        HttpCookie nameCookie = new HttpCookie("_SUser");
                //        nameCookie.Values["_SUser"] = user_web;
                //        nameCookie.Expires = DateTime.Now.AddHours(1);
                //        context.Response.Cookies.Add(nameCookie);
                //        nameCookie = new HttpCookie("_Slvl");
                //        nameCookie.Values["_Slvl"] = user.Level.ToString();
                //        nameCookie.Expires = DateTime.Now.AddHours(1);
                //        context.Response.Cookies.Add(nameCookie);

                //    }
                //}
                //string pass = MD5Encrypt(model.Password);
                //bool result;// = (ObjectResult)null;
                //json = "{";

                //result = db.existsUser(user);

                if (result == true)
                {
                    json += "\"result\" : \"true\",";
                    json += "\"messageSuccess\" : \"Bienvenido.\"";
                }
                else
                {
                    json += "\"result\" : \"false\",";
                    json += "\"messageError\" : \"El usuario no existe.\"";
                }
            }
            catch (Exception ex)
            {
                json += "\"result\" : \"false\",";
                json += "\"messageError\" : \"" + ex.Message + "\"";
            }
            json += "}";
            context.Response.ContentType = "texto/normal";
            context.Response.Write(json);
        }
        private bool SignInSimosDB(String user, string pass, ref CSimosUser loginUser)
        {
            COracle m_oracle;
            bool res = false;
            try
            {
                m_oracle = new COracle("192.168.0.23", "SEMPROD");
                res = m_oracle.queryUser(user, pass, ref loginUser);
            }
            catch (Exception EX)
            {
                res = false;
            }

            //Cursor = Cursors.Arrow;

            return res;
        }
        public static string GetSHA1(String texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}