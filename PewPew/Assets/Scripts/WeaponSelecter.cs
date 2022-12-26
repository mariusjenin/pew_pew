using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
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
    [SerializeField] private InputActionReference selectingReferenceL = null;
    [SerializeField] private InputActionReference selectingReferenceR = null;


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
        indexLeft = Mathf.Abs((indexLeft - 1) % weaponsLeft.Count);
        SelectLeft(indexLeft);
    }
    
    private void NextRight()
    {
        var selection = weaponsRight[indexRight];
        selection.weaponBehaviour.enabled = false;
        selection.selectedOnBoard.SetActive(false);
        indexRight = (indexRight + 1) % weaponsRight.Count;
        SelectRight(indexRight);
    }
    
    private void PreviousRight()
    {
        var selection = weaponsRight[indexRight];
        selection.weaponBehaviour.enabled = false;
        selection.selectedOnBoard.SetActive(false);
        indexRight = Mathf.Abs((indexRight - 1) % weaponsRight.Count);
        SelectRight(indexRight);
    }

    private void FixedUpdate() 
    {
        Vector2 joyStickSelectL = selectingReferenceL.action.ReadValue<Vector2>();
        float directionL = Vector2.Dot(joyStickSelectL, Vector2.right);

        Vector2 joyStickSelectR = selectingReferenceR.action.ReadValue<Vector2>();
        float directionR = Vector2.Dot(joyStickSelectR, Vector2.right);
        
        if(directionL > 0)
        {
            NextLeft();
        }
        else if(directionL < 0)
        {
            PreviousLeft();
        }

        if(directionR > 0)
        {
            NextRight();
        }
        else if(directionR < 0)
        {
            PreviousRight();
        }
    }
}