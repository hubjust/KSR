using Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    class Or : LinguisticVariable
    {
        public LinguisticVariable variable1;
        public LinguisticVariable variable2;

        public override double GetMembership(FifaPlayer FifaPlayer)
        {
            return Math.Max(variable1.GetMembership(FifaPlayer), variable2.GetMembership(FifaPlayer));
        }

        public override List<FifaPlayer> Support(List<FifaPlayer> players)
        {
            return variable1.Support(players).Concat(variable2.Support(players)).Distinct().ToList();
        }

        public override double DegreeOfFuzziness(List<FifaPlayer> players)
        {
            return variable1.DegreeOfFuzziness(players) * variable2.DegreeOfFuzziness(players);
        }

        public override List<LinguisticVariable> GetAllLinguisticVariables()
        {
            return variable1.GetAllLinguisticVariables().Concat(variable2.GetAllLinguisticVariables()).ToList();
        }

        public override void SetAllLinguisticVariables(List<LinguisticVariable> sets)
        {
            variable1 = sets[0];
            variable2 = sets[1];
        }
    }
}
