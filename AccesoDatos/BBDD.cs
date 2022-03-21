using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class BBDD
    {

        private SqlConnection connection;

        public BBDD()
        {
            connect();
        }

        /// <summary>
        /// Este método realiza la conexion a la base de datos.
        /// </summary>
        /// <returns>Boolean</returns>
        public void connect()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "tcp:hads2207.database.windows.net,1433";
                builder.UserID = "apelipian001@ikasle.ehu.eus@hads2207";
                builder.Password = "hadsaj2122@";
                builder.InitialCatalog = "HADS22-07";

                connection = new SqlConnection(builder.ConnectionString);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public SqlConnection getConnection()
        {
            return connection;
        }

        /// <summary>
        /// Este método realiza el cierre de la conexión de la Base de Datos.
        /// </summary>
        public void close()
        {
            connection.Close();
        }

        /// <summary>
        /// Este método realiza la apertura de la Base de Datos.
        /// </summary>
        public void open()
        {
            connection.Open();
        }

        /// <summary>
        /// Inserta un nuevo usuario a la base de datos con los valores enviados por parámetro.
        /// </summary>
        public Boolean insertUser(String email, String nombre, String apellidos, int numconfir, String tipo, String pass)
        {
            String sql = "INSERT INTO Usuarios VALUES(@email, @nombre, @apellidos, @numconfir, 0, @tipo, @pass, 0)";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);

            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@nombre", nombre);
            sqlCmd.Parameters.AddWithValue("@apellidos", apellidos);
            sqlCmd.Parameters.AddWithValue("@numconfir", numconfir);
            sqlCmd.Parameters.AddWithValue("@tipo", tipo);
            sqlCmd.Parameters.AddWithValue("@pass", pass);

            return (sqlCmd.ExecuteNonQuery() == 0);

        }

        /// <summary>
        /// El siguiente método actualiza el codPass de un determinado email
        /// cuando se desea cambiar la contraseña.
        /// </summary>
        /// <param name="email"></param>
        public void updateCodpass(String email)
        {
            Random generator = new Random();
            int codChangePass = int.Parse(generator.Next(0, 1000000).ToString("D6"));
            String sql = "UPDATE Usuarios SET codpass=@codChangePass WHERE email=@email";

            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@codChangepass", codChangePass);
            sqlCmd.Parameters.AddWithValue("@email", email);

            sqlCmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Retorna el codpass de una fila correspondiente al email enviado por parámetro
        /// </summary>
        /// <param name="email"></param>
        /// <returns>int codpass</returns>
        public int getCodpass(String email)
        {
            String sql = "SELECT codpass FROM Usuarios WHERE email=@email";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);
            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return int.Parse(string.Format("{0}", reader["codpass"]));
                }
            }
            return 0;
        }

        /// <summary>
        /// Actualiza en valor del campo pass en la base de datos
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public void updatePassword(String password, String email)
        {
            String sql = "UPDATE Usuarios SET pass=@password WHERE email=@email";

            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@password", password);
            sqlCmd.Parameters.AddWithValue("@email", email);

            sqlCmd.ExecuteNonQuery();
        }

        /// <summary>
        /// método que realiza la busquede del correo enviado por parámetro
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true tupla existente | false tupla inexistente</returns>
        public Boolean searchEmail(String email)
        {
            String sql = "SELECT email FROM Usuarios WHERE email=@email";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);

            SqlDataReader reader = sqlCmd.ExecuteReader();
            return reader.Read();
        }

        /// <summary>
        /// método que devuelve el campo contraseña de una tupla determinada correspondiente a 
        /// lo enviado por parámetro.        l
        /// </summary>
        /// <param name="Email"></param>
        /// <returns>password de la tupla correspondiente</returns>
        public string getPassword(String email)
        {
            String sql = "SELECT pass FROM Usuarios WHERE email=@email";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);

            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return string.Format("{0}", reader["pass"]);
                }
            }
            return "";
        }

        public bool getConfirmed(String email)
        {
            String sql = "SELECT confirmado FROM Usuarios WHERE email=@email";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);

            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return bool.Parse(string.Format("{0}", reader["confirmado"]));
                }
            }
            return false;
        }

        public void confirmAccount(String email)
        {
            String sql = "UPDATE Usuarios SET confirmado=@confirmado WHERE email=@email";

            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@confirmado", true);

            sqlCmd.ExecuteNonQuery();
        }

        public int getNumconfir(String email)
        {
            String sql = "SELECT numconfir FROM Usuarios WHERE email=@email";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);

            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return int.Parse(string.Format("{0}", reader["numconfir"]));
                }
            }
            return 0;
        }

        /// <summary>
        /// método que devuelve el campo tipo de una tupla determinada correspondiente a
        ///  lo enviado por parámetro. 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>el tipo de usuario con el correo correspondiente.</returns>
        public String getRol(String email)
        {
            String sql = "SELECT tipo FROM Usuarios WHERE email=@email";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);

            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return string.Format("{0}", reader["tipo"]);
                }
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool insertTarea(String codigo, String descripcion, String codAsig, int hEstimadas, String tipoTarea)
        {
            String sql = "INSERT INTO TareaGenerica VALUES(@codigo, @descripcion, @codAsig, @hEstimadas, @explotacion, @tipoTarea)";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);

            sqlCmd.Parameters.AddWithValue("@codigo", codigo);
            sqlCmd.Parameters.AddWithValue("@descripcion", descripcion);
            sqlCmd.Parameters.AddWithValue("@codAsig", codAsig);
            sqlCmd.Parameters.AddWithValue("@hEstimadas", hEstimadas);
            sqlCmd.Parameters.AddWithValue("@tipoTarea", tipoTarea);
            sqlCmd.Parameters.AddWithValue("@explotacion", false);
            try
            {

                sqlCmd.ExecuteNonQuery();
                return true;

            } catch(Exception e) {
                
                return false;

            }
        }

        public bool insertTareaConExplotacion(String codigo, String descripcion, String codAsig, int hEstimadas, bool explotacion, String tipoTarea)
        {
            String sql = "INSERT INTO TareaGenerica VALUES(@codigo, @descripcion, @codAsig, @hEstimadas, @explotacion, @tipoTarea)";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);

            sqlCmd.Parameters.AddWithValue("@codigo", codigo);
            sqlCmd.Parameters.AddWithValue("@descripcion", descripcion);
            sqlCmd.Parameters.AddWithValue("@codAsig", codAsig);
            sqlCmd.Parameters.AddWithValue("@hEstimadas", hEstimadas);
            sqlCmd.Parameters.AddWithValue("@tipoTarea", tipoTarea);
            sqlCmd.Parameters.AddWithValue("@explotacion", explotacion);
            try
            {

                sqlCmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception e)
            {

                return false;

            }
        }

        public bool instanciarTareaAlumno(String email, String cod, int estimadas, int reales)
        {
            String sql = "INSERT INTO EstudianteTarea VALUES (@email, @codTarea, @hEstimadas, @hReales)";

            SqlCommand sqlCmd = new SqlCommand(sql, connection);

            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@codTarea", cod);
            sqlCmd.Parameters.AddWithValue("@hEstimadas", estimadas);
            sqlCmd.Parameters.AddWithValue("@hReales", reales);

            try
            {

                sqlCmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception e)
            {

                return false;

            }
        }

        public List<String> getAsignaturasAlumno(String email)
        {
            List<String> asignaturas = new List<String>();

            String sql = "SELECT DISTINCT TareaGenerica.codAsig FROM EstudianteTarea INNER JOIN TareaGenerica ON EstudianteTarea.codTarea = TareaGenerica.codigo WHERE (EstudianteTarea.email = @email)";
            SqlCommand sqlCmd = new SqlCommand(sql, connection);
            sqlCmd.Parameters.AddWithValue("@email", email);

            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    asignaturas.Add(string.Format("{0}", reader["codAsig"]));
                }
            }
            return asignaturas;
        }

        public SqlDataAdapter getTareasFromDLL(String codAsig, String email)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TG.codigo, TG.descripcion, TG.hEstimadas, TG.explotacion, TG.tipoTarea " +
                "FROM TareaGenerica AS TG INNER JOIN GrupoClase ON TG.codAsig = GrupoClase.codigoAsig INNER JOIN ProfesorGrupo ON ProfesorGrupo.codigoGrupo = GrupoClase.codigo " +
                "WHERE TG.codAsig = @codAsig AND ProfesorGrupo.email = @email", connection);

            da.SelectCommand.Parameters.AddWithValue("@codAsig", codAsig);
            da.SelectCommand.Parameters.AddWithValue("@email", email);

            return da;
        }
        
        /*
        public SqlDataAdapter getTareasFromDLL(String codAsig, Boolean explotacion, String email)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * " +
            "FROM TareaGenerica INNER JOIN GrupoClase ON TareaGenerica.codAsig = GrupoClase.codigoAsig INNER JOIN ProfesorGrupo ON ProfesorGrupo.codigoGrupo = GrupoClase.codigo " +
            "WHERE TareaGenerica.codAsig = @codAsig AND ProfesorGrupo.email = @email AND TareaGenerica.explotacion = @explotacion", connection);

            da.SelectCommand.Parameters.AddWithValue("@codAsig", "%" + codAsig + "%");
            da.SelectCommand.Parameters.AddWithValue("@email", "%" + email + "%");
            da.SelectCommand.Parameters.AddWithValue("@explotacion", "%" + explotacion + "%");

            return da;
        }
        */

    }

}
