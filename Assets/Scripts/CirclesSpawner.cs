using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclesSpawner : MonoBehaviour
{   
    [SerializeField] private GameObject circlePrefub;
    [SerializeField] private float topSpawnBorder;
    [SerializeField] private float bottomSpawnBorder;
    [SerializeField] private float leftSpawnBorder;
    [SerializeField] private float rightSpawnBorder;
    [SerializeField] private float minCircleSize;
    [SerializeField] private float maxCircleSize;
    [SerializeField] private float spawnTime;

    private void Start(){
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine(){
        while(true){
            CreateNewCircle();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void CreateNewCircle(){
        GameObject circleObj = Instantiate(circlePrefub);
        Circle circle = circleObj.GetComponent<Circle>();
        Vector2 newSize = RandomizeCircleSize();
        Vector2 newPos = RandomizeCirclePosition(newSize);
        circle.ChangeSize(newSize);
        circle.ChangePosition(newPos);
        circle.RandomizeColor();
    }

    private Vector2 RandomizeCirclePosition(Vector2 size){
        float offset = size.x;
        float posX = Random.Range(leftSpawnBorder + offset, rightSpawnBorder - offset);
        float posY = Random.Range(bottomSpawnBorder + offset, topSpawnBorder - offset);
        Vector2 result = new Vector2(posX, posY);
        return result;
    }

    private Vector2 RandomizeCircleSize(){
        float size = Random.Range(minCircleSize, maxCircleSize);
        Vector2 result = new Vector2(size, size);
        return result;
    }
}

