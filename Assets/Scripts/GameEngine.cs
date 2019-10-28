using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    [SerializeField] GameObject[] options = new GameObject[3];
    [SerializeField] GameObject[] buildings = new GameObject[2];
    [SerializeField] static int MIN_X = -10, MAX_X = 10, MIN_Z = -10, MAX_Z = 10, UNITS = 6, BUILDINGS = 6;
    private int team1Resources, team2Resources;
    [SerializeField] Text teamText;

    public int Team1Resources { get => team1Resources; set => team1Resources = value; }
    public int Team2Resources { get => team2Resources; set => team2Resources = value; }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < UNITS; i++)
        {
            CreateUnit();
        }

        for (int k = 0; k < BUILDINGS; k++)
        {
            CreateBuilding();
        }

    }

    // Update is called once per frame
    void Update()
    {
        teamText.text = " Team 1(Red) resources: " + Team1Resources + "\n Team 2(Blue) Resources: " + Team2Resources;
    }

    void CreateUnit()
    {
        GameObject unit = Instantiate(options[Random.Range(0, 3)]);
        unit.transform.position = new Vector3(Random.Range(MIN_X, MAX_X), 0, Random.Range(MIN_Z, MAX_Z));

    }

    void CreateBuilding()
    {
        GameObject build = Instantiate(buildings[Random.Range(0, 2)]);
        build.transform.position = new Vector3(Random.Range(MIN_X, MAX_X), 0, Random.Range(MIN_Z, MAX_Z));
    }
}
