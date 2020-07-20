using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SpriteOutline : MonoBehaviour {
	public Color color1 = Color.white;
	public Color color2 = Color.white;

	[SerializeField]
	private SpriteRenderer _spriteRenderer;
	
	public SpriteRenderer spriteRenderer{
		get{
			if(_spriteRenderer == null){
				_spriteRenderer = GetComponent<SpriteRenderer>();
			}
			return _spriteRenderer;
		}
	}
	[SerializeField]
	private float _outlineSize = 1;

	private Material _preMat;

	void OnEnable() {
		if (spriteRenderer != null)
		{
			_preMat = spriteRenderer.sharedMaterial;
			spriteRenderer.sharedMaterial = defaultMaterial;
			UpdateOutline(_outlineSize);
		}
	}

	void OnDisable() {
		if (spriteRenderer != null)
		{
			spriteRenderer.sharedMaterial = _preMat;
		}
	}

	void UpdateOutline(float outline) {
		if (spriteRenderer != null)
		{
			MaterialPropertyBlock mpb = new MaterialPropertyBlock();
			spriteRenderer.GetPropertyBlock(mpb);
			mpb.SetFloat("_OutlineSize", outline);
			mpb.SetColor("_OutlineColor", color1);
			mpb.SetColor("_OutlineColor2", color2);
			spriteRenderer.SetPropertyBlock(mpb);
		}
	}
	

	void OnValidate(){
		if(enabled && spriteRenderer != null){
			UpdateOutline(_outlineSize);
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