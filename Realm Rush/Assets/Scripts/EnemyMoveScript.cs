using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyScript))]
public class EnemyMoveScript : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;

    EnemyScript enemyScript;
    private void Start()
    { 
        enemyScript = FindObjectOfType<EnemyScript>();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }
    private void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach(Transform child in parent.transform)
        {
            WayPoint wayPoint = child.GetComponent<WayPoint>();
            if (wayPoint != null)
            {
                path.Add(wayPoint);
            }
           
        }
    }
    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemyScript.PenalityGold();
        gameObject.SetActive(false);
    }
    private IEnumerator FollowPath()
    {
        foreach (WayPoint wayPoint in path)
        {
            Vector3 startPosition = transform.position;
            Debug.Log(wayPoint.name);
            Vector3 endingPosition = wayPoint.transform.position;
            float travelPercentage = 0f;
            transform.LookAt(endingPosition);
            while (travelPercentage < 1f)
            {
                travelPercentage += Time.deltaTime * speed;
                gameObject.transform.position = Vector3.Lerp(startPosition, endingPosition, travelPercentage);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}
