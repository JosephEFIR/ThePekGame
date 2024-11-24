using UnityEngine;

namespace Project.Scripts
{
    public class BRUH_MOMENT : MonoBehaviour
    {
        public Renderer objectRenderer; 
        public float changeSpeed = 2f; 
        private float hue = 0f; 

        private void Update()
        {
            hue += Time.deltaTime * changeSpeed;
            
            if (hue > 1f) hue -= 1f;
            
            Color rainbowColor = Color.HSVToRGB(hue, 1f, 1f); 
            objectRenderer.material.color = rainbowColor;
        }
    }
}