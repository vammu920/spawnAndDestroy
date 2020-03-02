using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Processes mouse button inputs
/// </summary>
public class MouseButtonProcessor : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    GameObject prefabTeddyBear;

    // first frame input support
    bool spawnInputOnPreviousFrame = false;
	bool explodeInputOnPreviousFrame = false;

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        
        if(Input.GetMouseButton(0)){
        if(!spawnInputOnPreviousFrame ){
            spawnInputOnPreviousFrame = true;
            Vector3 pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        // spawn teddy bear as appropriate
            
            Instantiate<GameObject>(prefabTeddyBear, pos, Quaternion.identity);
        }
        }
        else{
            spawnInputOnPreviousFrame = false;
        }
        if (Input.GetMouseButton(1))
        {
            // only explode teddy bear on first frame of input
            if (!explodeInputOnPreviousFrame)
            {
                // set input flag
                explodeInputOnPreviousFrame = true;

                // try to find a teddy bear
                GameObject teddyBear = GameObject.FindWithTag("TeddyBear");
                if (teddyBear != null)
                {
                    Instantiate(prefabExplosion, teddyBear.transform.position, Quaternion.identity);
                    Destroy(teddyBear);
                }
            }
        }
        else
        {
            // no explode teddy bear input
            explodeInputOnPreviousFrame = false;
        }
        // explode teddy bear as appropriate
		
	}
}
