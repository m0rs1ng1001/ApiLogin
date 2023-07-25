using ApiLogin.modelos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Abstractions;


namespace ApiLogin.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly string cadenaSQL;
        public UsuarioController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }


        // listar usuario

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<usuario> lista = new List<usuario>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("listar_correo2", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new usuario
                            {
                                id_usuarioR = Convert.ToInt32(rd["id_usuarioR"]),
                                nombresR = rd["nombresR"].ToString(),
                                apellidosR = rd["apellidosR"].ToString(),
                                telefonoR = rd["telefonoR"].ToString(),
                                correoR = rd["correoR"].ToString(),
                                contraseñaR = rd["contraseñaR"].ToString()

                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });
            }
        }




        // obtener usuario

        [HttpGet]
        [Route("Obtener/{id_usuarioR:int}")]
        public IActionResult Obtener(int id_usuarioR)
        {
            List<usuario> lista = new List<usuario>();
            usuario ousuario = new usuario();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("listar_correo2", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new usuario
                            {
                                id_usuarioR = Convert.ToInt32(rd["id_usuarioR"]),
                                nombresR = rd["nombresR"].ToString(),
                                apellidosR = rd["apellidosR"].ToString(),
                                telefonoR = rd["telefonoR"].ToString(),
                                correoR = rd["correoR"].ToString(),
                                contraseñaR = rd["contraseñaR"].ToString()
                            });
                        }
                    }
                }
                ousuario = lista.Where(item => item.id_usuarioR == id_usuarioR).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = ousuario });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = ousuario });
            }
        }
    }



    



}
