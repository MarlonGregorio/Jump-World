using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPipe : MonoBehaviour {

    public GameObject cyclo;
    public GameObject bomobMan;

    public bool spawnCyclo;

    public bool spawnBombMan;
    [Space]
    public int spawnCount;
    public int currentSpawnCount;

    private Controller theController;

    private int counter;

	void Start(){
        theController = FindObjectOfType<Controller>();
        counter = 180;
	}
	
	void Update(){

        if (Mathf.Abs(transform.position.x - theController.gameObject.transform.position.x) < 150)
        {

            if(currentSpawnCount < spawnCount)
            {

                counter++;

                if(counter >= 200)
                {
                    if (spawnCyclo)
                    {
                        var clone = Instantiate(cyclo, transform.position + new Vector3(0,-5,0), Quaternion.identity);
                        clone.GetComponent<EnemyHealthManager>().theESP = GetComponent<EnemySpawnPipe>();
                    }

                    else if (spawnBombMan)
                    {
                        //instatiate bombman
                    }


                    currentSpawnCount++;
                    counter = 0;
                }

                
                
            }




        }
    }


}