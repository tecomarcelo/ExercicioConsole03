using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDOS03.Interfaces
{
    /// <summary>
    /// Interface padrão para definir os metodos dos repositores
    /// </summary>
    public interface IBaseRepository<T>
    {
        #region metodos abstratos

        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
        List<T> GetAll();

        #endregion
    }
}
