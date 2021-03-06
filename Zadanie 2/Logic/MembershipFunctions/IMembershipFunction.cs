﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.MembershipFunctions
{
    public interface IMembershipFunction
    {
        double GetMembership(double x);
        List<IMembershipFunction> GetAllFunctions();
        double Cardinality();
        double Support();
    }
}
