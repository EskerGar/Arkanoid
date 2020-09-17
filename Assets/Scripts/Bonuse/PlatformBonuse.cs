using UnityEngine;

namespace Bonuse
{
    public class PlatformBonuse : IBonuse
    {

        private const float Lengthen = .1f;
    
        public void BonuseLogic()
        {
            Object.FindObjectOfType<Platform.Platform>().transform.localScale += new Vector3(Lengthen, 0f);
        }
    
    }
}