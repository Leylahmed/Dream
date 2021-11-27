using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyData", menuName = "ScriptableObjects/KeyData")]
public class KeyDataSO : ScriptableObject
{
    [SerializeField] private bool isKeyActive;
    [SerializeField] private bool isDoorActive;
    [SerializeField] private int life;
    [SerializeField] private int bombParts;
    public bool GetIsKeyActive()
    {
        return isKeyActive;
    }

    public void SetIsKeyActive(bool isKeyActive)
    {
        this.isKeyActive = isKeyActive;
    }
    public bool GetIsDoorActive()
    {
        return isDoorActive;
    }
    public void SetIsDoorActive(bool isDoorActive)
    {
        this.isDoorActive = isDoorActive;
    }
    public int GetLife()
    {
        return life;
    }
    public void SetLife(int life)
    {
        this.life = life;
    }

    public int GetBombParts()
    {
        return bombParts;
    }
    public void SetBombParts(int bombParts)
    {
        this.bombParts = bombParts;
    }

}
