﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    internal interface IAttackable
    {

        public void AttackPerformed();
        public void AttackCanceled();
    }
}
