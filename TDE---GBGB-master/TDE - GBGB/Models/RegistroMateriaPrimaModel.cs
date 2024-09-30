namespace TDE___GBGB.Models
{
    public class RegistroMateriaPrimaModel
    {
        public long IdRegistro { get; set; }
        public long IdMateriaPrima { get; set; }
        public long IdProduto { get; set; }
        public long IdFornecedor { get; set; }
        public long IdUsuario { get; set; }
        public double QuantidadeKG { get; set; }
        public DateTime DataProducao { get; set; }
        public DateTime DataLote { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
