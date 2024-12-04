using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace appticketcambio.DATA
{
    public class UserRepository
    {
        private readonly string _jsonPath;

        public UserRepository()
        {
            _jsonPath = ConfigurationManager.AppSettings["UsrImpresionJsonPath"];
        }

        public List<Usuarious> LoadUsers()
        {
            if (File.Exists(_jsonPath))
            {
                string jsonContent = File.ReadAllText(_jsonPath);
                var userData = JsonConvert.DeserializeObject<UserData>(jsonContent);
                return userData.usuarios.OrderBy(u => u.NombreUsuario).ToList(); ;
     
            }
            else
            {
                throw new FileNotFoundException($"No se pudo encontrar el archivo JSON de usuarios en la ruta: {_jsonPath}");
            }
        }
    }

    public class UserData
    {
        public List<Usuarious> usuarios { get; set; }
    }

    public class Usuarious
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
    }
}
