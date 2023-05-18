using Full_Stack_Mercury_Maps.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Full_Stack_Mercury_Maps.Repositories
{
    public interface IClientRepository
    {
        Client GetClientById(int id);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
    }

}
