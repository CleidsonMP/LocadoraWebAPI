using Locadora.Models;
using System;
using System.Linq;

namespace Locadora.Services
{
    public class FuncionariosSeguranca
    {
        public static bool Login(string login, string senha)
        {
            using (FuncionarioDBContext entities = new FuncionarioDBContext())
            {
                return entities.Usuarios.Any(user =>
               user.Login.Equals(login, StringComparison.OrdinalIgnoreCase)
               && user.Senha == senha);
            }
        }
    }
}