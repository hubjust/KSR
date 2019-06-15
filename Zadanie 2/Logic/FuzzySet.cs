using Logic.Database;
using Logic.MembershipFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class FuzzySet
    {
        public IMembershipFunction MembershipFunction { get; set; }
        public Func<FifaPlayer, double> FieldExtractor { get; set; }

        public virtual double GetMembership(FifaPlayer player)
        {
            return MembershipFunction.GetMembership(FieldExtractor(player));
        }

        private List<FifaPlayer> Support(List<FifaPlayer> entries, IMembershipFunction function)
        {
            List<FifaPlayer> result = new List<FifaPlayer>();
            entries.ForEach((e) =>
            {
                if (function.GetMembership(FieldExtractor(e)) > 0)
                {
                    result.Add(e);
                }
            });
            return result;
        }
    }
}
