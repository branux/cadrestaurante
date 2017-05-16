using System;

namespace FN.CadRestaurante.Domain.Entities
{
    public class RestaurantePrato
    {
        protected RestaurantePrato() { }

        public RestaurantePrato(Restaurante restaurante, Prato prato)
        {
            Restaurante = restaurante;
            Prato = prato;
        }

        public Guid RestauranteId { get; private set; }
        public Restaurante Restaurante { get; private set; }

        public Guid PratoId { get; private set; }
        public Prato Prato { get; private set; }
    }
}
