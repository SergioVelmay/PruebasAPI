using MongoDB.Driver;
using RotuladoresInfrastructure.Collections;


namespace RotuladoresInfrastructure.Context
{
    public interface IRotuladorContext
    {
        IMongoCollection<RotuladorCollection> GetCollection();
    }
}
