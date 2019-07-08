using System.Collections;
using System.Collections.Generic;
using PaletteSwapping;
using UnityEngine;
using UnityEngine.UI;

namespace HexRL.UI
{
    [ExecuteInEditMode]
    public class UIColorPaletteComponent : MonoBehaviour
    {

        //reference to palette scriptable object
        [SerializeField] private ColorPaletteScriptable selectedPalette;
        
        //reference to ui image component
        private Image _image;
        
        //shader property id
        private static readonly int PaletteTex = Shader.PropertyToID("_PaletteTex");

        private void Awake()
        {
            _image = GetComponent<Image>();

            SetPalette(selectedPalette);
        }

        #if UNITY_EDITOR
        private void Update()
        {
            if (Application.isPlaying)    //to save performance in play mode
                return;
            
            SetPalette(selectedPalette);
        }
        #endif

        public void SetPalette(ColorPaletteScriptable palette)
        {
            if (palette == null)
                return;
            
            _image.material.SetTexture(PaletteTex, palette.GetTexture());
        }
    }
}