using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] telephones;
    public List<Transform> telephonesList;
    // Start is called before the first frame update
    void Awake()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddTelephones()
    {
        telephones = telephonesList.ToArray();
    }
}
