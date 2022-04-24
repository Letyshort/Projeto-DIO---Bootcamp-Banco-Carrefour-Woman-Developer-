using System.Collections.Generic;
namespace Projeto_DIO___Bootcamp_Banco_Carrefour_Woman_Developer.Interface
{
    public interface IRepositório<T>
    {
         List<T> Lista();

         T RetornaPorId(int id);

         void Insere(T entidade);

         void Exclui(int id);

         void Atualiza(int id, T entidade);
         
         int ProximoId();
    }
}