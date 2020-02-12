using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotuladoresInfrastructure.Collections
{
    public class RotuladorCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        #region Rotulador

        [BsonElement("Name")]
        public string Nombre { get; set; }

        public string Color { get; set; }

        public double Grosor { get; set; }

        public bool Permanente { get; set; }

        [BsonElement("Nivel")]
        public int NivelTinta { get; set; }

        public bool? Descatalogado { get; set; }

        #endregion

        #region Usuario

        public string Tipo { get; set; }

        [BsonElement("Nombre")]
        public string NombreUsuario { get; set; }

        public int Edad { get; set; }

        public double Altura { get; set; }

        public bool Cliente { get; set; }

        #endregion

    }
}
