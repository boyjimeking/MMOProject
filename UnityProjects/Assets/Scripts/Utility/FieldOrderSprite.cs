using UnityEngine;
using System.Collections;

namespace YCG
{
    [ExecuteInEditMode]
    public class FieldOrderSprite : MonoBehaviour
    {
        SpriteRenderer _sprite;

        void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
            if(_sprite == null)
                _sprite = GetComponentInChildren<SpriteRenderer>();
        }

        void Update()
        {
            if (_sprite != null)
            {
                Vector3 pos = transform.position;
                float x2 = Mathf.Sign(pos.x) * pos.x * pos.x;
                float z2 = -1 * Mathf.Sign(pos.z) * pos.z * pos.z;
                _sprite.sortingOrder = (int)(Mathf.Sqrt(x2 + z2) * 10);
            }
        }
    }
}