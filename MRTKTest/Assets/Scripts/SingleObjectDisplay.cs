using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleObjectDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _stand;
    [SerializeField] private GameObject _conveyer1;
    [SerializeField] private GameObject _conveyer2;
    [SerializeField] private GameObject _buncer;
    [SerializeField] private GameObject _camera;
    private List<GameObject> _objects;
    int _flag = 0;
    // Update is called once per frame
    private void Start()
    {
        _objects = new List<GameObject>() { _stand, _buncer, _conveyer1, _conveyer2 };
    }
    private void Replace(int flag)
    {
        _objects[_flag].SetActive(false);
        _objects[flag].SetActive(true);
        Vector3 coords =_camera.transform.position;
        coords.z += 1f;
        _objects[flag].transform.position = coords;
        _flag = flag;
    }
    public void PushButton1()
    {
        int flag = 1;
        Replace(flag);
    }
    public void PushButton2()
    {
        int flag = 2;
        Replace(flag);
    }
    public void PushButton3()
    {
        int flag = 3;
        Replace(flag);
    }
    public void PushHome()
    {
        int flag = 0;
        Replace(flag);
    }
    
}
