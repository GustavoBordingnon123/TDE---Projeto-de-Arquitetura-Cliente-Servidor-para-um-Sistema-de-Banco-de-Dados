using TDE___GBGB.Models;
using TDE___GBGB.Repositories;

namespace TDE___GBGB.Services
{
    public class RegistroMateriaPrimaService : IRegistroMateriaPrimaService
    {
        private readonly IRegistroMateriaPrimaRepository _registroMateriaPrimaRepository;

        public RegistroMateriaPrimaService(IRegistroMateriaPrimaRepository registroMateriaPrimaRepository)
        {
            _registroMateriaPrimaRepository = registroMateriaPrimaRepository;
        }

        public ResultadoRegistroMateriaPrimaModel ListaRegistrosMateriaPrima()
        {
            var registro = _registroMateriaPrimaRepository.ListaRegistrosMateriaPrima();

            if (registro.Count != 0)
            {
                return new ResultadoRegistroMateriaPrimaModel
                {
                    Sucesso = true,
                    Mensagem = "Registros listados com sucesso.",
                    Registro = registro
                };
            }
            else
            {
                return new ResultadoRegistroMateriaPrimaModel
                {
                    Sucesso = false,
                    Mensagem = "Nenhum registro cadastrado.",
                    //caso n tenha gera uma lista vazia
                    Registro = new List<RegistroMateriaPrimaModel>()
                };
            }
        }


        public ResultadoRegistroMateriaPrimaModel ListaRegistroMateriaPrima(int id)
        {
            var registro = _registroMateriaPrimaRepository.ListaRegistroMateriaPrima(id);

            if (registro != null)
            {
                return new ResultadoRegistroMateriaPrimaModel
                {
                    Sucesso = true,
                    Mensagem = "Registro listado com sucesso.",
                    Registro = registro
                };
            }
            else
            {
                return new ResultadoRegistroMateriaPrimaModel
                {
                    Sucesso = false,
                    Mensagem = "Nenhum registro encontrado."
                };
            };
        }

        public ResultadoRegistroMateriaPrimaModel AdicionaRegistroMateriaPrima(RegistroMateriaPrimaModel registro)
        {

            _registroMateriaPrimaRepository.AdicionaRegistroMateriaPrima(registro);

            return new ResultadoRegistroMateriaPrimaModel
            {
                Sucesso = true,
                Mensagem = "Registro adicionado com sucesso."
            };
        }

        public ResultadoRegistroMateriaPrimaModel EditaRegistroMateriaPrima(RegistroMateriaPrimaModel registro, int id)
        {
            _registroMateriaPrimaRepository.EditaRegistroMateriaPrima(registro, id);

            return new ResultadoRegistroMateriaPrimaModel
            {
                Sucesso = true,
                Mensagem = "Registro editado com sucesso."
            };
        }

        public void DeletaRegistroMateriaPrima(int id)
        {
            _registroMateriaPrimaRepository.DeletaRegistroMateriaPrima(id);

        }
    }
}
