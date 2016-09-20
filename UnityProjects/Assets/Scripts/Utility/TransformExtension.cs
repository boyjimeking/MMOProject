using UnityEngine;

public static class TransformExtension
{
    private static Vector3 vec;

    #region LocalScale
    public static void SetLocalScaleX(this Transform transform, float v)
    {
        vec.Set(v, transform.localScale.y, transform.localScale.z);
        transform.localScale = vec;
    }
    #endregion
}
