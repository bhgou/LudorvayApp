using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupMenu : MonoBehaviour
{
    [SerializeField] private IndexMenu _index;
    [SerializeField] private IdMenu[] _ids;

    private void Start()
    {
        Setup();
    }
    public void Setup()
    {


        foreach (var menu in _ids)
        {
            menu.gameObject.SetActive(false);
            if(menu.ID == _index.Index)
            {
                menu.gameObject.SetActive(true);
            }
        }
    }

}
