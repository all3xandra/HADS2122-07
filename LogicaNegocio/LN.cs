using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace LogicaNegocio
{
    public class LN
    {

        private AccesoDatos.BBDD bd = new AccesoDatos.BBDD();
        private MD5 hash = MD5.Create();

        /// <summary>
        /// método que realiza el envió de correo electronico.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="email"></param>
        /// <returns>true si envio el correo satisfactorio | false si fallo en envio de correo </returns>
        public Boolean sendMail(String subject, String body, String email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("hads2207@gmail.com");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hads2207@gmail.com", "hadsaj2122@");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// método que realiza una llamada al método de insertar datos de la base de datos.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="numconfir"></param>
        /// <param name="tipo"></param>
        /// <param name="pass"></param>
        /// <returns>true correcto insert de datos. |false fallo en insertar datos.</returns>
        public Boolean insertUser(String email, String nombre, String apellidos, int numconfir, String tipo, String pass)
        {
            String hash_pass = getHash(pass);
            bd.open();
            bool resul = bd.insertUser(email, nombre, apellidos, numconfir, tipo, hash_pass);
            bd.close();
            return resul;
        }

        public String getHash(String text)
        {
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes(text);
                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                // Convert hash byte array to string
                String hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return hash.ToLower();
            }
        }

        public void updateCodpass(String email)
        {
            bd.open();
            bd.updateCodpass(email);
            bd.close();
        }

        /// <summary>
        /// método que realiza una llamada al método getCodPass de la base de datos y
        /// retorna el codpass
        /// </summary>
        /// <param name="email"></param>
        /// <returns>codpass</returns>
        public int getCodpass(String email)
        {
            bd.open();
            int resul = bd.getCodpass(email);
            bd.close();
            return resul;
        }

        /// <summary>
        /// método que realiza una llamada al método UpdatePassword de la base de datos y
        /// lo ejecuta con los parámetros indicados.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public void updatePassword(String password, String email)
        {
            bd.open();
            bd.updatePassword(password, email);
            bd.close();
        }

        public bool searchEmail(String email)
        {
            bd.open();
            bool resul = bd.searchEmail(email);
            bd.close();
            return resul;
        }

        public string getPassword(String email)
        {
            bd.open();
            string resul = bd.getPassword(email);
            bd.close();
            return resul;
        }

        public bool getConfirmed(String email)
        {
            bd.open();
            bool resul = bd.getConfirmed(email);
            bd.close();
            return resul;
        }

        public void confirmAccount(String email)
        {
            bd.open();
            bd.confirmAccount(email);
            bd.close();
        }

        public int getNumconfir(String email)
        {
            bd.open();
            int resul = bd.getNumconfir(email);
            bd.close();
            return resul;
        }
        public String getRol(String email)
        {
            bd.open();
            String resul = bd.getRol(email);
            bd.close();
            return resul;
        }

        public bool insertTarea(String codigo, String descripcion, String codAsig, int hEstimadas, String tipoTarea)
        {
            bd.open();
            bool resul = bd.insertTarea(codigo, descripcion, codAsig, hEstimadas, tipoTarea);
            bd.close();
            return resul;
        }

        public bool insertTareaConExplotacion(String codigo, String descripcion, String codAsig, int hEstimadas, bool explotacion, String tipoTarea)
        {
            bd.open();
            bool resul = bd.insertTareaConExplotacion(codigo, descripcion, codAsig, hEstimadas, explotacion, tipoTarea);
            bd.close();
            return resul;
        }

        public bool instanciarTareaAlumno(String email, String cod, int estimadas, int reales)
        {
            bd.open();
            bool resul = bd.instanciarTareaAlumno(email, cod, estimadas, reales);
            bd.close();
            return resul;
        }

        public List<String> getAsignaturasAlumno(String email)
        {
            bd.open();
            List<String> resul = bd.getAsignaturasAlumno(email);
            bd.close();
            return resul;
        }

        public SqlDataAdapter getTareasFromDLL(String codAsig, String email)
        {
            bd.open();
            SqlDataAdapter da = bd.getTareasFromDLL(codAsig, email);
            bd.close();
            return da;
        }


    }
}
