using spraynprayscore.api.Contracts;
using spraynprayscore.api.entities;
using spraynprayscore.api.entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spraynprayscore.api.Repository
{
    public class ScoreRepository: RepositoryBase<Score>, IScoreRepository
    {
        public ScoreRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Score> ScoresByWeapon(string weapon)
        {
            return FindByCondition(a => a.Weapon.Equals(weapon)).OrderBy(w => w.TheScore);
             
        }
        public IEnumerable<Score> GetAllScores()
        {
            return FindAll()
                .OrderBy(score => score.Weapon)
                .ToList();

        }
        public Score GetTopScoreByWeapon(string weapon)
        {
            return ScoresByWeapon(weapon).DefaultIfEmpty(new Score()).FirstOrDefault();
              
        }
        public Score GetScoreById(Guid scoreId)
        {
            return FindByCondition(score => score.Id.Equals(scoreId))
                    .DefaultIfEmpty(new Score())
                    .FirstOrDefault();
        }

        public Score CreateScore(Score score)
        {
            score.Id = Guid.NewGuid();
            Create(score);
            return (score);
        }
        public void DeleteScore(Score score)
        {
            Delete(score);
        }

    }
}
