using UnityEngine;
using System.Collections;

namespace YCG
{
    [ExecuteInEditMode]
    public class Billboard : MonoBehaviour
    {
        void Update()
        {
            transform.LookAt(Camera.main.transform.position);
        }
    }
}
