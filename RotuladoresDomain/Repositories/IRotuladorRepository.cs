using MongoDB.Driver;
using RotuladoresDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotuladoresDomain.Repositories
{
    public interface IRotuladorRepository
    {
        List<Rotulador> Get();

        Rotulador Get(string id);

        Rotulador Create(Rotulador rotulador);

        void Update(string id, Rotulador rotuladorIn);

        void Remove(Rotulador rotuladorIn);

        void Remove(string id);
    }
}
