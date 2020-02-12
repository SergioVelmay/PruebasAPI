using System;
using System.Collections.Generic;
using System.Text;
using RotuladoresDomain;

namespace RotuladoresInfrastructure.Mongo
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
