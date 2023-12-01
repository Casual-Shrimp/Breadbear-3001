using UnityEngine;

public class DownScroll : MonoBehaviour
{
    private float _scrollSpeed = 1.0f;
    private float _offset;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        _offset += (Time.deltaTime * _scrollSpeed) / 10.0f;
        mat.SetTextureOffset("_MainTex", new Vector2(0, _offset));

    }
}
