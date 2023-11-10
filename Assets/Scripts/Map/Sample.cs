using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YandexMaps;
using TMPro;

public class Sample : MonoBehaviour
{
    public RawImage image;
    public Map.TypeMap typeMap;
    public Map.TypeMapLayer mapLayer;
    public List<Vector2> markers = new List<Vector2>();
    public TMP_Text _text;
    private void Update()
    {
        LoadMap();
    }

    public void LoadMap()
    {
        Map.EnabledLayer = true;
        Map.Size = 4;
        Map.SetTypeMap = typeMap;
        Map.SetTypeMapLayer = mapLayer;
        Map.SetMarker = markers;
        Vector3 xyz_vector = Quaternion.AngleAxis(Map.Longitude, -Vector3.up) * Quaternion.AngleAxis(Map.Latitude, -Vector3.right) * new Vector3(0, 0, 1);
        _text.text  = $"{Map.Longitude}, {Map.Latitude},\nX:{xyz_vector.x} Y:{xyz_vector.y}";
        Map.LoadMap();
        StartCoroutine(GetTexture());
    }

    IEnumerator GetTexture()
    {
        yield return new WaitForSeconds(1f);
        image.texture = Map.GetTexture;

    }
}