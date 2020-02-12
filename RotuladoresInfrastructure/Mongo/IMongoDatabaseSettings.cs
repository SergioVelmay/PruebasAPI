using System;
using System.Collections.Generic;
using System.Text;

namespace RotuladoresInfrastructure.Mongo
{
    public interface IMongoDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
