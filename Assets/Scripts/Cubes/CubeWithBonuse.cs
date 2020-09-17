using Bonuse;
using UnityEngine;
using static Bonuse.BonusePool;

namespace Cubes
{
    public class CubeWithBonuse: Cube
    {
        [SerializeField] private GameObject bonuse;
        [SerializeField] [Range(0, 1)] private float bonuseChance;
        protected override void BeforeDestroy()
        {
            if(!CanCreateBonuse()) return;
            var obj = Instantiate(bonuse, transform.position, Quaternion.identity);
            obj.GetComponent<BonuseBehaviour>().Initialize(GetRandomBonuse());
        }

        private bool CanCreateBonuse()
        {
            var chance = Random.Range(0f, 1f);
            return chance <= bonuseChance;
        }
    
    }
}