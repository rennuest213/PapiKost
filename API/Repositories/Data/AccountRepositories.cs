using API.Context;
using API.Handler;
using API.Models;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class AccountRepositories : GeneralRepository<User>

    {
        private readonly MyContext myContext;

        public AccountRepositories(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public ICollection<User> Get()
        {
            return myContext.tb_m_Users.ToList();
        }

        public User GetById(int Id)
        {
            return myContext.tb_m_Users.Find(Id);
        }

        public int Create(User entity)
        {
            myContext.tb_m_Users.Add(entity);
            var data = myContext.SaveChanges();
            return data;
        }

        public int Update(User entity)
        {
            myContext.Entry(entity).State = EntityState.Modified;
            var data = myContext.SaveChanges();
            return data;
        }

        public int Delete(int Id)
        {
            var data = myContext.tb_m_Users.Find(Id);
            if (data != null)
            {
                myContext.tb_m_Users.Remove(data);
                var result = myContext.SaveChanges();
                return result;
            }
            return 0;
        }

        public LoginResponse Login(string email, string password)
        {
            var data = myContext.tb_m_Users.Include(x => x.Role)
               .FirstOrDefault(x => x.Email == email);

            if (data != null)
            {

                LoginResponse loginResponse = new LoginResponse()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Email = data.Email,
                    Role = data.Role.Name

                };
                var validate = Hashing.ValidatePassword(password, data.Password);
                if (validate == true)
                    return loginResponse;
            }

            return null;
        }

        public int Register(string name, string email, string tanggal_lahir, string no_hp, string alamat, string password)
        {
            //if (myContext.tb_m_Users.Any(x => x.Email == email))
            //{
            //    return 0;
            //}
            //User user = new User()
            //{
            //    Name = name,
            //    Email = email,
            //    Tanggal_Lahir = tanggal_lahir,
            //    No_Hp = no_hp,
            //    Alamat = alamat,    
            //    Password = password
            //};
            //myContext.tb_m_Users.Add(user);
            
            var validate = myContext.tb_m_Users.SingleOrDefault(x => x.Email.Equals(email));
            if (validate == null)
            {
                //var create = myContext.SaveChanges();
                //if (create > 0)
                //{
                    var id = 0/*myContext.tb_m_Users.SingleOrDefault(x => x.Email.Equals(email)).Id*/;
                    User user = new User()
                    {
                        Id = id,
                        Name = name,
                        Email = email,
                        Tanggal_Lahir = tanggal_lahir,
                        No_Hp = no_hp,
                        Alamat = alamat,
                        Password = Hashing.HashPassword(password),
                        RoleId = 2
                    };

                    myContext.tb_m_Users.Add(user);
                    var result = myContext.SaveChanges();
                    if (result > 0)
                    {
                        return result;
                    }
                //}
            }
            return 0;
        }

        public int ChangePassword(string email,string passwordSekarang,string passwordBaru)
        {
            var data = myContext.tb_m_Users
                .SingleOrDefault(x => x.Email.Equals(email));
            var validate = Hashing.ValidatePassword(passwordSekarang, data.Password);
            if (data != null && validate)
            {
                data.Password = Hashing.HashPassword(passwordBaru);
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0)
                    return result;
            }
            return 0;
        }


        public int ForgotPassword(string email, string passwordBaru)
        {
            var data = myContext.tb_m_Users
                .SingleOrDefault(x => x.Email.Equals(email));
            if (data != null)
            {
                data.Password = Hashing.HashPassword(passwordBaru);
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0)
                    return result;

            }
            return 0;
        }


    }
}
