using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Interfaces
{
    public interface IObserver<T> where T : class
    {
        void Update(T provider);
        List<T> GetObservables();
    }
}
