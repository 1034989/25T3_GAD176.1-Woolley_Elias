using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponList", menuName = "WeaponList", order = 0)]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public int ammoCount;
    public int clipSize;

    private void OnEnable()
    {
        // ammo is full when the game starts
        ammoCount = clipSize;
    }
    public void ShootWeapon()
    {
        ammoCount--;
        Debug.Log("Shooting " + weaponName + ". Ammo left: " + ammoCount + "/" + clipSize);
    }
    public void reloadWeapon()
    {
        ammoCount = clipSize;
        Debug.Log("Reloading " + weaponName + ". Ammo filled: " + ammoCount + "/" + clipSize);
    }
}
