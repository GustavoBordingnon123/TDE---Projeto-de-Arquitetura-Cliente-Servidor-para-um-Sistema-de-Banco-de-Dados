using TDE___GBGB.Models;

namespace TDE___GBGB.Repositories
{
    public interface IRegistroMateriaPrimaRepository
    {
        public List<RegistroMateriaPrimaModel> ListaRegistrosMateriaPrima();
        public RegistroMateriaPrimaModel ListaRegistroMateriaPrima(int id);
        public void AdicionaRegistroMateriaPrima(RegistroMateriaPrimaModel registro);
        public void EditaRegistroMateriaPrima(RegistroMateriaPrimaModel registro, int id);
        public void DeletaRegistroMateriaPrima(int id);
    }
}
