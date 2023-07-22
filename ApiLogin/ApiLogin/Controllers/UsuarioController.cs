using ApiLogin.modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;


namespace ApiLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly string cadenaSQL;
        public UsuarioController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

    }



    [HttpGet]
    [Route("Obtener/{id_usuario:int}")]
    public IActionResult Obtener(int id_usuario)
    {
        List<usuario> lista = new List<usuario>();
        usuario ousuario = new usuario();
        try
        {
            using (var conexion = new SqlConnection(cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("usar_correo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lista.Add(new usuario
                        {
                            correo = rd["correo"].ToString(),
                            contraseña = rd["contraseña"].ToString(),
                        });
                    }
                }
            }
            ousuario = lista.Where(item => item.id_usuario == id_usuario).FirstOrDefault();
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = ousuario });
        }
        catch (Exception error)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = ousuario });
        }
    }



}
