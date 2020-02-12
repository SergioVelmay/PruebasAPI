using System;
using System.Collections.Generic;
using System.Text;

namespace RotuladoresDTO
{
    public class RotuladorDTO
    {
        #region PROPIEDADES

        /// <summary>
        /// Identificador único del rotulador.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Indica la marca del rotulador.
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Indica el modelo del rotulador.
        /// </summary>
        public string Modelo { get; set; }

        /// <summary>
        /// Indica el color de la tinta del rotulador.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Indica el grosor de la punta del rotulador.
        /// </summary>
        public double Grosor { get; set; }

        /// <summary>
        /// Indica si el rotulador es o no permatente.
        /// </summary>
        public bool Permanente { get; set; }

        /// <summary>
        /// Indica el nivel de tinta restante del rotulador.
        /// </summary>
        public int NivelTinta { get; set; }

        #endregion
    }
}
