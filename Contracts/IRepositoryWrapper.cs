using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spraynprayscore.api.Contracts
{
    public interface IRepositoryWrapper
    {
        IScoreRepository Score { get; }
        void Save();
    }
}
