using spraynprayscore.api.Contracts;
using spraynprayscore.api.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spraynprayscore.api.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        private IScoreRepository _score;

        public IScoreRepository Score
        {
            get
            {
                if(_score == null)
                {
                    _score = new ScoreRepository(_repoContext);
                }
                return _score;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
