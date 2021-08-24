using System.ComponentModel.DataAnnotations;

namespace FruitEcommerce.ApplicationCore.Entities
{
    public class Fruit
    {
        [Display(Name = "Id")]
        public int FruitId { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Foto")]
        public byte[] Photo { get; set; }

        [Display(Name = "Quantidade")]
        public int Quantity { get; set; }

        [Display(Name = "Estoque")]
        public int Stock { get; set; }

        [Display(Name = "Valor")]
        public decimal Value { get; set; }
    }
}
