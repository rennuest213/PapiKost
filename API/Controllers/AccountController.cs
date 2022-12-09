using API.Handler;
using API.Repositories.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private JWTConfig jwtConfig;
        private readonly AccountRepositories accountRepositories;

        public AccountController(JWTConfig jwtConfig, AccountRepositories accountRepositories)
        {
            this.accountRepositories = accountRepositories;
            this.jwtConfig = jwtConfig;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(LoginVM login)
        {
            var data = accountRepositories.Login(login.Email, login.Password);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Login gagal",
                    });
                }
                else
                {
                    //JWTConfig jwt = new JWTConfig();
                    string token = jwtConfig.Token(login.Email, data.Role, data.Id, data.Name);
                    //string role = data.Role;
                    return Ok(token); 
                //    {
                //        //Message = "Login Berhasil",
                //        token

                    //}
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterVM register)
        {
            var data = accountRepositories.Register(register.Name,  register.Email,  register.Tanggal_Lahir,  register.No_Hp,  register.Alamat,  register.Password);

            try
            {
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Email sudah ada !"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Berhasil",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpPut("ChangePassword")]
        public ActionResult ChangePassword(string email, string passwordSekarang,string passwordBaru  )
        {

            var data = accountRepositories.ChangePassword(email,passwordSekarang, passwordBaru );
            try
            {
                if (data == 0)
                {
                    return Ok(new { Message = "error" });
                }
                else
                {
                    return Ok(new
                    {
                        Message = "Password Barhasil Diubah",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }


        [HttpPut("ForgotPassword")]
        public ActionResult ForgotPassword(string email,string passwordBaru)
        {
            var data = accountRepositories.ForgotPassword(email, passwordBaru);
            try
            {
                if (data == 0)
                {
                    return Ok(new
                    {
                        Message = "Gagal"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Message = "Sukses",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
    }
}
