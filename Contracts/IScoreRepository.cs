using spraynprayscore.api.entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spraynprayscore.api.Contracts
{
    public interface IScoreRepository
    {
        IEnumerable<Score> ScoresByWeapon(string weapon);
        IEnumerable<Score> GetAllScores();
        Score GetTopScoreByWeapon(string score);
        Score GetScoreById(Guid scoreId);
        Score CreateScore(Score score);
        void DeleteScore(Score score);
    }
}
