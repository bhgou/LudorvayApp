using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "infoConfig")]
public class InfoSystem : ScriptableObject
{
    public string SheetId;
    public string GridId;
    public List<InfoConfig> infoConfigs;

    [ContextMenu("Sync")]
    public void Sync()
    {
        ReadGoogleSheets.FillData<InfoConfig>(SheetId, GridId,list =>
        {
            infoConfigs = list;
            ReadGoogleSheets.SetDirty(this);
        });
    }

}
[System.Serializable]
public class InfoConfig
{
    public string name;
    public string date;
    public string image;
    public string text;
  
}
