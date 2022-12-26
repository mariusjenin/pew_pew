using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using weapon;

public class WeaponSelecter : MonoBehaviour
{
    [SerializeField] private int indexLeft;
    [SerializeField] private int indexRight;
    
    [Serializable]
    public class WeaponSelectable
    {
        [SerializeField] public WeaponBehaviour weaponBehaviour;
        [SerializeField] public GameObject selectedOnBoard;
    }

    [SerializeField] private List<WeaponSelectable> weaponsLeft;
    [SerializeField] private List<WeaponSelectable> weaponsRight;

    private void Start()
    {
        ClearSelection();
        SelectLeft(indexLeft);
        SelectRight(indexRight);
    }

    private void ClearSelection()
    {
        foreach (var weaponSelectable in weaponsLeft)
        {
            weaponSelectable.weaponBehaviour.enabled = false;
            weaponSelectable.selectedOnBoard.SetActive(false);
        }
        foreach (var weaponSelectable in weaponsRight)
        {
            weaponSelectable.weaponBehaviour.enabled = false;
            weaponSelectable.selectedOnBoard.SetActive(false);
        }
    }

    private void SelectLeft(int index)
    {
        var selection = weaponsLeft[index];
        selection.weaponBehaviour.enabled = true;
        selection.selectedOnBoard.SetActive(true);
    }

    private void SelectRight(int index)
    {
        var selection = weaponsRight[index];
        selection.weaponBehaviour.enabled = true;
        selection.selectedOnBoard.SetActive(true);
    }

    private void NextLeft()
    {
        var selection = weaponsLeft[indexLeft];
        selection.weaponBehaviour.enabled = false;
        selection.selectedOnBoard.SetActive(false);
        indexLeft = (indexLeft + 1) % weaponsLeft.Count;
        SelectLeft(indexLeft);
    }
    
    private void PreviousLeft()
    {
        var selection = weaponsLeft[indexLeft];
        selection.weaponBehaviour.enabled = false;
        selection.selectedOnBoard.SetActive(false);
        indexLeft = (indexLeft - 1) % weaponsLeft.Count;
        SelectLeft(indexLeft);
    }
    
    private void NextRight()
    {
        var selection = weaponsRight[indexRight];
        selection.weaponBehaviour.enabled = false;
        selection.selectedOnBoard.SetActive(false);
        indexRight = (indexRight + 1) % weaponsRight.Count;
        SelectLeft(indexRight);
    }
    
    private void PreviousRight()
    {
        var selection = weaponsRight[indexRight];
        selection.weaponBehaviour.enabled = false;
        selection.selectedOnBoard.SetActive(false);
        indexRight = (indexRight - 1) % weaponsRight.Count;
        SelectLeft(indexRight);
    }
}