using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, ITargetable
{
    private Color _targetColor = Color.red;
    private Color initialColor;
    [SerializeField] private int givenPoints;


    private Material _currentMaterial;
    void Start()
    {
        _currentMaterial = GetComponent<Renderer>().material;
        initialColor = _currentMaterial.color;
    }

    public int StartTarget()
    {
        Destroy(gameObject);
        return getPoints();
    }


    public int getPoints()
    { return givenPoints; }
    
    

    //public void notLookedAt()
    //{
    //    _currentMaterial.color = initialColor;
    //}    

}
