using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    int stopAfterOne;

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && stopAfterOne < 1)
        {
            GetComponent<Animator>().Play("DoorClose");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().TypewriterEffect("What the hell!? The door just closed behind me! Crap! I gotta find a way out of here!"));
        stopAfterOne++;
        }
    }

}
