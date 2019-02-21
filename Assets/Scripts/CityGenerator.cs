using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    [SerializeField] private GameObject buildingPrefab;
    [SerializeField] private Material[] buildingMaterials;
    [SerializeField] private int numberOfStreets;
    [SerializeField] private int minBuildingWidth;
    [SerializeField] private int maxBuildingWidth;
    [SerializeField] private int minBuildingHeigth;
    [SerializeField] private int maxBuildingHeigth;
    

    private void Start()
    {
        MeshRenderer buildingMaterial = buildingPrefab.GetComponentInChildren<MeshRenderer>();
        Collider planeCol = GetComponent<Collider>();
        float placeForBuiding = 500f / numberOfStreets;
        //center of start point
        Vector3 zeroPoint = new Vector3 (planeCol.bounds.min.x+placeForBuiding/2, 0f,
                                         planeCol.bounds.min.z+placeForBuiding/2);
        Debug.Log(zeroPoint);
        if (placeForBuiding <= maxBuildingWidth)
        {
            Debug.Log("Please choose less width of Max Building Width");
        }
        for (int i = 1; i <= numberOfStreets; i++)
        {
            for (int j = 1; j <= numberOfStreets; j++)
            {
                buildingPrefab.transform.localScale = new Vector3(
                    Random.Range(minBuildingWidth, maxBuildingWidth),
                    Random.Range(minBuildingHeigth, maxBuildingHeigth),
                    Random.Range(minBuildingWidth, maxBuildingWidth)
                    );
                buildingMaterial.material = buildingMaterials[Random.Range(0, buildingMaterials.Length)];
                Instantiate(buildingPrefab, 
                    new Vector3(zeroPoint.x,zeroPoint.y-buildingPrefab.transform.localScale.y/2,zeroPoint.z), 
                    Quaternion.identity);
                zeroPoint.x += placeForBuiding;
            }
            zeroPoint.x = planeCol.bounds.min.x + placeForBuiding/2;
            zeroPoint.z += placeForBuiding;
        }

    }
}
