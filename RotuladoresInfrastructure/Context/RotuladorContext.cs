using MongoDB.Driver;
using RotuladoresDomain.Models;
using RotuladoresInfrastructure.Collections;
using RotuladoresInfrastructure.Mongo;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotuladoresInfrastructure.Context
{
    public class RotuladorContext : IRotuladorContext
    {
        private readonly IMongoCollection<RotuladorCollection> _rotuladorCollection;

        public RotuladorContext(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _rotuladorCollection = database.GetCollection<RotuladorCollection>(settings.CollectionName);
        }

        public IMongoCollection<RotuladorCollection> GetCollection()
        {
            return _rotuladorCollection;
        }
    }
}
