using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace PaletteSwapping
{
    [CreateAssetMenu(fileName = "ColorPaletteScriptable", menuName = "ScriptableObjects/ColorPaletteScriptable")]
    public class ColorPaletteScriptable : ScriptableObject
    {
        //array of colors that will be on palette
        [SerializeField] private List<Color> colors;
        
        //generated palette texture. Allows to generate each palette only once for performance purposes
        private Texture2D _texture;
        
        public Texture2D GetTexture()
        {
            //if texture has already been generated, return it
            if (Application.isPlaying && _texture != null)
                return _texture;
            
            //height of texture will be 1, and width is equal to amount of colors
            Texture2D texture = new Texture2D(colors.Count, 1, TextureFormat.RGBA32, false);
            //go through all colors in array
            for (int i = 0; i < colors.Count; i++)
            {
                //set color of pixel to corresponding element of array
                texture.SetPixel(i, 0, colors[i]);
            }
            
            //set texture settings
            texture.filterMode = FilterMode.Point;
            texture.wrapMode = TextureWrapMode.Clamp;
            
            //apply changes
            texture.Apply();
            
            //save generated texture
            if (Application.isPlaying)
                _texture = texture;
            
            return texture;
        }
    }
}