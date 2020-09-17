using System.Collections.Generic;
using Platform;
using UnityEngine;

namespace Bonuse
{
        public static class BonusePool
        {
                private static readonly List<IBonuse> Bonuses = new List<IBonuse>(){new SpeedBonuse(), new PlatformBonuse(), new BonuseBall()};

                public static IBonuse GetRandomBonuse() => Bonuses[Random.Range(0, Bonuses.Count)];
        }
}