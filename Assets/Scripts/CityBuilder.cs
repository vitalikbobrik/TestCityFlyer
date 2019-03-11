using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CityBuilder : MonoBehaviour
{
    public GameObject m_HousePrefab;

    [Header("City:")]
    public float m_CitySize;

    [Header("Street")]
    public float m_StreetWidth = 2F;

    [Header("House min values:")]
    public float m_HouseHeightMin = 10F;
    public float m_HouseWidthMin = 10F;
    public float m_HouseDepthMin = 10F;

    [Header("House max values:")]
    public float m_HouseHeightMax = 10F;
    public float m_HouseWidthMax = 10F;
    public float m_HouseDepthMax = 10F;

    [Header("Cube settings:")]
    public GameObject m_GoldCubePrefab;
    public float DistanceToHouse;
    public int m_CountOfCubes;

    [Header("AirPlane prefabs:")]
    public GameObject [] AirPlane;

    private static CityBuilder instance;
    public static CityBuilder Instance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<CityBuilder>();
        }
        return instance;
    }

    private List <GameObject> m_allHouses = new List<GameObject>();
    [HideInInspector]
    public  List <GameObject> m_AllCubes = new List<GameObject>();

    public void BuildCity()
    {
        Debug.Log("CityBuilder : BuildCity : ");

        CreateGround(m_CitySize);

        float _cellMax = this.GetCellMax();
        int _housesCountSide = (int)(m_CitySize / _cellMax);

        for (int i = 0; i <= _housesCountSide; i++)
        {
            Vector3 _pos = Vector3.zero;
            _pos.x = _cellMax * i;

            for (int j = 0; j <= _housesCountSide; j++)
            {
                _pos.z = _cellMax * j;
                if (InstanceHouse(_pos) == null)
                {
                    Debug.LogError("CityBuilder : BuildCity : house null");
                    return;
                }
                
            }
        }
    }

    

    private float GetCellMax()
    {
        float _cellMax = 0;
        if (m_HouseWidthMax > m_HouseDepthMax) _cellMax = m_HouseWidthMax;
        else _cellMax = m_HouseDepthMax;

        Debug.Log("CityBuilder : GetCellMax : _cellMax = " + _cellMax);
        return _cellMax + m_StreetWidth;
    }



    private GameObject InstanceHouse(Vector3 pos)
    {
        if (m_HousePrefab)
        {
            GameObject _house = Instantiate(m_HousePrefab, pos, Quaternion.identity) as GameObject;
            _house.transform.localScale = GetRandomHouseSize();
            _house.GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV();
            m_allHouses.Add(_house);
            return _house;
        }
        else
        {
            Debug.LogError("CityBuilder : InstanceHouse : m_HousePrefab == null");
            return null;
        }
    }


    private Vector3 GetRandomHouseSize()
    {
        float _height = Random.Range(m_HouseHeightMin, m_HouseHeightMax);
        float _width = Random.Range(m_HouseWidthMin, m_HouseWidthMax);
        float _depth = Random.Range(m_HouseDepthMin, m_HouseDepthMax);
        Vector3 _size = new Vector3(_width, _height, _depth);
        return _size;
    }

    private void CreateGround(float size)
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.localScale = new Vector3(size / 10, 1, size / 10);
        plane.transform.position = new Vector3(size / 2, 0, size / 2);
        plane.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public void PlaceCubes()
    {
        for (int i = 0; i < NumberOfCubes.m_numberOfCubes; i++)
        {
            GameObject houseWithCube = m_allHouses[Random.Range(0, m_allHouses.Count)];
            Vector3 pos = new Vector3(houseWithCube.transform.position.x,
            houseWithCube.transform.position.y + houseWithCube.transform.localScale.y + DistanceToHouse,
            houseWithCube.transform.position.z);
            GameObject cube = Instantiate(m_GoldCubePrefab, pos, Quaternion.identity);
            m_AllCubes.Add(cube);
        }
    }

    private void PlaceAirPlane()
    {
        GameObject airPlaneHouse = m_allHouses[Random.Range(0, m_allHouses.Count)];
        Vector3 pos = new Vector3(airPlaneHouse.transform.position.x,
            airPlaneHouse.transform.position.y + airPlaneHouse.transform.localScale.y + 1f,
            airPlaneHouse.transform.position.z);
        Instantiate(AirPlane[SelectAirPlane.m_currentIndex], pos, Quaternion.identity);
    }


    private void Awake()
    {
        Debug.Log("CityBuilder : Start : ");
        BuildCity();
        PlaceCubes();
        PlaceAirPlane();
    }

    
}
