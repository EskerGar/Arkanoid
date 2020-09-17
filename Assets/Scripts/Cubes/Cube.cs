using UnityEngine;
using Random = UnityEngine.Random;

namespace Cubes
{
    public class Cube : MonoBehaviour
    {
        private int _health = 1;
        private TextMesh _textHealth;

        public void Initialize(int maxHealth)
        {
            _health = Random.Range(1, maxHealth);
            _textHealth = gameObject.GetComponentInChildren<TextMesh>();
            _textHealth.text = _health.ToString();
        }
    
    
        public void TakeDamage()
        {
            _health -= 1;
            _textHealth.text = _health.ToString();
            if(_health != 0) return;
            CubeGeneration.CubeList.Remove(this);
            BeforeDestroy();
            Destroy(gameObject); 
        }
    
        protected virtual void BeforeDestroy()
        {}
    

    }
}
