using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleObjectDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _stand;
    [SerializeField] private Material _standText;
    [SerializeField] private GameObject _conveyer1;
    [SerializeField] private Material _covveyer1Text;
    [SerializeField] private GameObject _conveyer2;
    [SerializeField] private GameObject _buncer;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _menu;
    private List<GameObject> _objects;
    [SerializeField] private GameObject _infopanel;
    [SerializeField] private GameObject _text;
    private List<Material> _materials;

    int _flag = 0;
    // Update is called once per frame
    private void Start()
    {
        _objects = new List<GameObject>() { _stand, _buncer, _conveyer1, _conveyer2, _menu };
        _materials = new List<Material>() { _standText, _covveyer1Text };
    }
    private void Replace(int flag)
    {   
        if (flag == 4)
        {
            _menu.transform.localScale *= 2;
        }
        if (_flag == 4)
        {
            _menu.transform.localScale /= 2;
        }
        if (flag == 0)
        {
            _menu.SetActive(true);
        }
        if (_flag == 0)
        {
            _menu.SetActive(false);
        }
        
        _objects[_flag].SetActive(false);
        _objects[flag].SetActive(true);
        Vector3 coords =_stand.transform.position;
        coords.y += 0.6f;
        coords.x += 0.25f;
        _objects[flag].transform.position = coords;
        coords.x -= 1f;
        _infopanel.transform.position = coords;
        Quaternion rotate = _infopanel.transform.rotation;
        rotate.y = 0;
        _infopanel.transform.rotation = rotate;
        _text.GetComponent<MeshRenderer>().material = _materials[1];
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
    public void PushMenu()
    {
        int flag = 4;
        Replace(flag);
    }
    public void PushHome()
    {
        int flag = 0;
        Replace(flag);
    }
    
}
