using ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATAACCESS.Abstract
{
    public interface IUyeRepository
    {
        IEnumerable<Uye> GetAll();
        Uye GetById(Guid id);
        void InsertUye(Uye uye);          
        void UpdateUye(Uye uye);
        void DeleteUye(Guid id);
    }
}
