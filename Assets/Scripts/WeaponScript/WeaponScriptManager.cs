using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to allow on prefab to have multiple shooting method
// of course I did this because I'm lazy to make prefab -_-
public class WeaponScriptManager : MonoBehaviour
{
    private MonoBehaviour[] ScriptList;
    private int weaponIndex = 0;
    private int weaponNum;

    void Start()
    {
        ScriptList = GetComponents<MonoBehaviour>();
        weaponNum = ScriptList.Length - 1;
        Debug.Log("Collected " + weaponNum + " Weapon Scripts");
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Debug.Log("Scroll up");
            ScriptList[weaponIndex].enabled = false;
            if (++weaponIndex >= weaponNum) weaponIndex = 0;
            ScriptList[weaponIndex].enabled = true;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            Debug.Log("Scroll down");
            ScriptList[weaponIndex].enabled = false;
            if (--weaponIndex < 0) weaponIndex = weaponNum - 1;
            ScriptList[weaponIndex].enabled = true;
        }
    }
}
