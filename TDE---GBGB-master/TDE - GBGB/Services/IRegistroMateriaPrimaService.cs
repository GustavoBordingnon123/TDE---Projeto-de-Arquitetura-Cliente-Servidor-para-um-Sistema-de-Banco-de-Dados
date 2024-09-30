using TDE___GBGB.Models;

namespace TDE___GBGB.Services
{
    public interface IRegistroMateriaPrimaService
    {
        public ResultadoRegistroMateriaPrimaModel ListaRegistrosMateriaPrima();
        public ResultadoRegistroMateriaPrimaModel ListaRegistroMateriaPrima(int id);
        public ResultadoRegistroMateriaPrimaModel AdicionaRegistroMateriaPrima(RegistroMateriaPrimaModel produto);
        public ResultadoRegistroMateriaPrimaModel EditaRegistroMateriaPrima(RegistroMateriaPrimaModel usuario, int id);
        public void DeletaRegistroMateriaPrima(int id);
    }
}
