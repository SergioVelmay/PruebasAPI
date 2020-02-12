using MongoDB.Driver;
using RotuladoresDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotuladoresInfrastructure.Context
{
    public interface IRotuladorContext
    {
        IMongoCollection<Rotulador> GetCollection();
    }
}
