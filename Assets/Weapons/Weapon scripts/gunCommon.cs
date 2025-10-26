using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunCommon : MonoBehaviour
{
    public Weapon weaponEquipped;
    public int weaponIndex;
    public List<Weapon> allWeapons = new List<Weapon>();
    public List<Weapon> allInstancedWeapons = new List<Weapon>();
    // Start is called before the first frame update
    void Start()
    {
        createWeaponInstances();
        weaponIndex = 0;
        weaponEquipped = allWeapons[weaponIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))// Change weapon
        { 
            weaponIndex++;
            if (weaponIndex >= allWeapons.Count)
            {
                weaponIndex = 0;
            }
            weaponEquipped = allWeapons[weaponIndex];
            Debug.Log("Switched to: " + weaponEquipped.weaponName);// Debug message to confirm weapon switch
        }
        if (Input.GetMouseButtonDown(0))
        {
            // Fire the weapon
            weaponEquipped.ShootWeapon();
        }
        if (Input.GetKeyDown(KeyCode.R)) // Reload weapon
        {
            weaponEquipped.reloadWeapon();
        }
        {
            
        }
    }
    void createWeaponInstances()
    {
        for (int i = 0; i < allWeapons.Count; i++)
        {
            allInstancedWeapons.Add(ScriptableObject.Instantiate(allWeapons[i]));
        }

    }
}
