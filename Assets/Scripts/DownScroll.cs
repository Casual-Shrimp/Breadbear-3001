using UnityEngine;

public class DownScroll : MonoBehaviour
{
    private readonly float _scrollSpeed = 3.0f;
    private float _offset;
    private Material _mat;

    // Start is called before the first frame update
    void Start()
    {
        _mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        _offset += (Time.deltaTime * _scrollSpeed) / 10.0f;
        _mat.SetTextureOffset("_MainTex", new Vector2(0, _offset));

    }
}
