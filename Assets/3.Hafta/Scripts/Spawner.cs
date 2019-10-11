using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] shapes;
    public int indis;
    public int shapeCount = 10;
    int shapeLeft = 0;
    float spawnSeconds = 1f;

    bool isNotSpawning = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isNotSpawning)
        {
            SpawnShapes();
        }
    }

    IEnumerator SpawnsShapes()
    {
        isNotSpawning = false; 

        for ( int i = 0; i < shapeCount; i++) {
            indis = Random.Range(0, shapes.Length);
            Instantiate(shapes[indis], this.transform.position, shapes[indis].transform.rotation);
            shapeLeft = (shapeCount - i)-1;
            yield return new WaitForSeconds(spawnSeconds);
        }
        shapeLeft = 0;
        isNotSpawning = true;
    }

    private void OnGUI()
    {
        Rect textBoxPos = new Rect(20, 50, 60, 30);
        GUI.TextArea(textBoxPos, shapeLeft + "");
    }

    void SpawnShapes()
    {
        StartCoroutine(SpawnsShapes());
    }
}
