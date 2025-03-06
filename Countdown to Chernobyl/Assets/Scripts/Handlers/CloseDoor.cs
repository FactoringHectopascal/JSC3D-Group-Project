using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    int stopAfterOne;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && stopAfterOne < 1)
        {
        GameObject.FindGameObjectWithTag("Door").GetComponentInChildren<Animator>().Play("DoorClose");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<Interaction>().TypewriterEffect("Did the door just close behind me!? Crap! I gotta seek a way out of here!"));
        stopAfterOne++;
        }
    }
}
