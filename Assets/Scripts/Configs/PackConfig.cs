using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Pack", menuName = "PackConfig", order = 51)]
public class PackConfig : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private int _packPrice;
    [SerializeField] private string _packName;
    [SerializeField] private Sprite _contentImage;
    [SerializeField] private List<GameObject> _listPrefabs;

    public int id => _id;
    public int packPrice => _packPrice;
    public string packName => _packName;
    public Sprite contentImage => _contentImage;
    public List<GameObject> listPrefabs => _listPrefabs;
}

