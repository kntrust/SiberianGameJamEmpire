using UnityEngine;

public class HouseWind : MonoBehaviour
{
    public float speed; // Скорость вращения
    public Vector3 axis = new Vector3(0, 0, 1);
    public GameObject _object;
    public GameObject _objectPig;
    void Start()
    {
    }

    void Update()
    {        _object.transform.Rotate(axis, Space.World);
        _objectPig.transform.Rotate(axis, Space.World);

        transform.Translate(Vector3.up * speed / 2 * Time.deltaTime);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

}
