using MongoDB.Driver;
using RotuladoresDomain.Models;
using RotuladoresInfrastructure.Context;
using System.Collections.Generic;

namespace RotuladoresDomain.Repositories
{
    public class RotuladorRepository : IRotuladorRepository
    {
        private readonly IMongoCollection<Rotulador> _rotuladores;

        public RotuladorRepository(IRotuladorContext rotuladorCollection)
        {
            _rotuladores = rotuladorCollection.GetCollection();
        }

        public List<Rotulador> Get() =>
            _rotuladores.Where().Find(rotulador => true).ToList();

        public Rotulador Get(string id) =>
            _rotuladores.Find<Rotulador>(rotulador => rotulador.Id == id).FirstOrDefault();

        public Rotulador Create(Rotulador rotulador)
        {
            _rotuladores.InsertOne(rotulador);
            return rotulador;
        }

        public void Update(string id, Rotulador rotuladorIn) =>
            _rotuladores.ReplaceOne(rotulador => rotulador.Id == id, rotuladorIn);

        public void Remove(Rotulador rotuladorIn) =>
            _rotuladores.DeleteOne(rotulador => rotulador.Id == rotuladorIn.Id);

        public void Remove(string id) =>
            _rotuladores.DeleteOne(rotulador => rotulador.Id == id);
    }
}
