﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson
{
    public class Outlook
    {
        public Morals Moral { get; }
        public Ethics Ethic { get; }

        public Outlook(Morals moral, Ethics ethics)
        {
            Moral = moral;
            Ethic = ethics;
        }

        public float GetOutlookEquivalent()
            => (float)Moral * (float)Ethic;
    }
}