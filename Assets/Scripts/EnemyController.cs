using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    private Path thePath;
    private int currentPoint;
    public float timeBetweenAttacks, damagePerAttack;
    private float attackCounter;
    private Castle theCastle;

    private bool reachedEnd;

    // Start is called before the first frame update
    void Start()
    {
        if (thePath == null) 
        { 
            thePath = FindObjectOfType<Path>();
        }

        if (theCastle == null)
        {
            theCastle = FindObjectOfType<Castle>();
        }

        attackCounter = timeBetweenAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reachedEnd)
        {
            transform.LookAt(thePath.points[currentPoint]);

            transform.position = Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < .01f)
            {


                currentPoint = currentPoint + 1;
                if (currentPoint >= thePath.points.Length)
                {
                    reachedEnd = true;
                }
            }
        } else
        {
            attackCounter -= Time.deltaTime; 
            if (attackCounter <= 0)
            {
                attackCounter = timeBetweenAttacks;
                theCastle.TakeDamage(damagePerAttack);
            }
        }
    }

    public void Setup(Castle newCastle, Path newPath)
    {
        theCastle = newCastle;
        thePath = newPath;
    }

}
