using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TesteHortoInova.Models
{
    public class pedidos_encerrados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Column("idpedido")]
        public int IdPedido { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("produto")]
        public string Produto { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("valorunitario")]
        public decimal ValorUnitario { get; set; }

        [Column("comprador")]
        public string Comprador { get; set; }

        [Column("plataforma")]
        public string Plataforma { get; set; }

        [Column("formapgt")]
        public string FormaPgt { get; set; }

        [Column("desconto")]
        public decimal Desconto { get; set; }

        [Column("valortotal")]
        public decimal ValorTotal { get; set; }

        [Column("marketplace")]
        public string Marketplace { get; set; }

        [Column("dataAddPedido")]
        public DateTime DataPedido { get; set; }
    }
}
