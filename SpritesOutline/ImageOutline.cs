using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ImageOutline : MonoBehaviour {
	public Color color1 = Color.white;
	public Color color2 = Color.white;
	
	[SerializeField] 
	private Image _image;

	[SerializeField]
	private float _outlineSize = 1;

	private Material _preMat;

	void OnEnable() {
		if (_image != null)
		{
			_preMat = _image.material;
			_image.material = defaultMaterial;
			UpdateOutlineUI(_outlineSize);
		}
	}

	void OnDisable() {
		if (_image != null)
		{
			_image.material = _preMat;
		}
	}

	
	void UpdateOutlineUI(float outline) {
		if (_image != null)
		{
			_image.material.SetFloat("_OutlineSize", outline);
			_image.material.SetColor("_OutlineColor", color1);
			_image.material.SetColor("_OutlineColor2", color2);
		}
	}

	void OnValidate(){
		if (enabled && _image != null)
		{
			UpdateOutlineUI(_outlineSize);
		}
	}


	private static Material _defaultMaterial = null;
	public static Material defaultMaterial{
		get{
			if(_defaultMaterial == null){
				_defaultMaterial = Resources.Load<Material>("Sprite-Outline");
			}
			return _defaultMaterial;
		}
	}
}