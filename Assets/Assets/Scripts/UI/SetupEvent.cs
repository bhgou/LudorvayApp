using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SetupEvent : MonoBehaviour
{
    [SerializeField] private InfoSystem _infoSystem;
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _prefabPost;

    private void Start()
    {
        _infoSystem.Sync();
        for (int i = 0; i < _infoSystem.infoConfigs.Count; i++)
        {
            var postObj = Instantiate(_prefabPost);
            postObj.transform.SetParent(_content);
            postObj.transform.localScale = new Vector3(1, 1, 1);
            Post post = postObj.GetComponent<Post>();
            post.Name.text = _infoSystem.infoConfigs[i].name;
            post.Date.text = _infoSystem.infoConfigs[i].date;
            post.Text.text = _infoSystem.infoConfigs[i].text;
        }
    }
}
