using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotuladoresDomain.Models
{
    public class Rotulador
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Nombre { get; set; }

        public string Color { get; set; }

        public double Grosor { get; set; }

        public bool Permanente { get; set; }

        [BsonElement("Nivel")]
        public int NivelTinta { get; set; }

        public bool? Descatalogado { get; set; }
    }
}
