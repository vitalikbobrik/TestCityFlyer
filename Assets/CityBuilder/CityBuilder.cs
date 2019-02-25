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


    private void Start()
    {
        Debug.Log("CityBuilder : Start : ");
        BuildCity();
    }

    
}
