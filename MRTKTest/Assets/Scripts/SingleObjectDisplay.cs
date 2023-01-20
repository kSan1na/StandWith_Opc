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
    [SerializeField] private GameObject managePanel;
    [SerializeField] private GameObject _infopanel;
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _menuConveyor1;
    [SerializeField] private GameObject _menuConveyor2;
    [SerializeField] private GameObject _menuBuncker;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _panel;
    private List<GameObject> _objects;
    private List<Material> _materials;
    private List<GameObject> _menus;
    private int _flag = 0;
    // Update is called once per frame
    private void Start()
    {
        
        _objects = new List<GameObject>() { _stand, _buncer, _conveyer1, _conveyer2, managePanel };
        _materials = new List<Material>() { _standText, _covveyer1Text };
        _menus = new List<GameObject>() { _mainMenu, _menuBuncker, _menuConveyor1,_menuConveyor2,_menuPanel};
    }
    private void Replace(int flag)
    {   
        
        if (flag == 0)
        {
            _panel.SetActive(true);
        }
        if (_flag == 0)
        {
            _panel.SetActive(false);
        }

        Vector3 coordsOfCurrentMenu = _menus[_flag].transform.position;
        _menus[_flag].SetActive(false);
        _menus[flag].SetActive(true);
        _menus[flag].transform.position = coordsOfCurrentMenu;
        _objects[_flag].SetActive(false);
        _objects[flag].SetActive(true);
        if (flag != 0) { 
            _text.GetComponent<MeshRenderer>().material = _materials[1]; 
            Vector3 coords =_stand.transform.position;
            coords.y += 0.6f;
            coords.x += 0.25f;
            _objects[flag].transform.position = coords;
            coords.x -= 1f;
            _infopanel.transform.position = coords;
            Quaternion rotate = _infopanel.transform.rotation;
            rotate.y = 0;
            _infopanel.transform.rotation = rotate;
        }
        else
        {
            _infopanel.SetActive(false);
        }
        _flag = flag;
        
    }
    public void PushButton(int flag)
    {
        Replace(flag);
    }
    
}
