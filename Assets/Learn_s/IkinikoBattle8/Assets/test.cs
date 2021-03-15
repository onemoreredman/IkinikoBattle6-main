using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        transform.MoveTo(new Vector3(1, 1, 1));
    }
}

static class MyTween
{
    public static Transform MoveTo(this Transform tran, Vector3 vector3)
    {
        tran.position = vector3;

        return tran;
    }
}