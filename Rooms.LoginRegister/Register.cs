using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rooms.Entity;
using Rooms;

namespace Rooms.LoginRegister
{
    public class Register
    {
        public utilizator Valideaza_Inregistrare(string username, string password, string firstname, string lastname, string confirmPassword, bool checkInstructor, string email)
        {
            Rol_Utilizator rol = Rol_Utilizator.Membru;

            if (!CheckIfUserExists(username))
            {
                if (checkInstructor)
                {
                    rol = Rol_Utilizator.Administrator;
                }
                if (CheckPassword(password, confirmPassword) && IsValidEmail(email))
                {
                    using (RoomsContext elearningContext = new RoomsContext())
                    {
                        elearningContext.Utilizator.Add(new utilizator()
                        {
                            firstname = firstname,
                            lastname = lastname,
                            username = username,
                            password = password,
                            Role = rol,
                            email = email
                        });
                        elearningContext.SaveChanges();
                        var newId = elearningContext.Utilizator.Max(x => x.id);

                        var returnedUser = elearningContext.Utilizator.Where(x => x.id == newId).ToList().FirstOrDefault();
                        return returnedUser;
                    }

                }
                else
                {
                    throw new System.Exception("Parola sau Email invalid");
                }

            }
            else
            {
                throw new System.Exception("Utilizator deja existent");
            }

        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckPassword(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                //min 6 chars, max 12 chars
                if (password.Length < 6 || password.Length > 12)
                    return false;

                //No white space
                if (password.Contains(" "))
                    return false;

                //At least 1 upper case letter
                if (!password.Any(char.IsUpper))
                    return false;

                //At least 1 lower case letter
                if (!password.Any(char.IsLower))
                    return false;

                //No two similar chars consecutively
                for (int i = 0; i < password.Length - 1; i++)
                {
                    if (password[i] == password[i + 1])
                        return false;
                }

                //At least 1 special char
                string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
                char[] specialCharactersArray = specialCharacters.ToCharArray();
                foreach (char c in specialCharactersArray)
                {
                    if (password.Contains(c))
                        return true;
                }
            }

            return false;
        }

      

        public bool CheckIfUserExists(string username)
        {
            using (RoomsContext elearningContext = new RoomsContext())
            {
                var users = elearningContext.Utilizator.Where(x => x.username == username).ToList();
                if (users.Count() > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
