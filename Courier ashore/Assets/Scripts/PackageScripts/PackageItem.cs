using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageItem : MonoBehaviour
{
    public Package packageInfo;
    public GameObject outline;
    public GameObject packageTrackerPrefab;
    public GameObject destinationIsland;
    private bool canPickup = false;
    private bool pickedUp = false;
    private IslandPackageManager islandPackageManager;
    [HideInInspector] public GameObject receiverNPC;
    [HideInInspector] public GameObject tracker;

    private Transform playerPos;
    private GameObject packageTracker;
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        packageTracker = Instantiate(packageTrackerPrefab, playerPos.position, Quaternion.identity);
        packageTracker.GetComponent<PackageTracker>().target = transform;

        islandPackageManager = FindObjectOfType<IslandPackageManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;
        if (otherObj.tag == "Player")
        {
            outline.SetActive(true);
            canPickup = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;
        if (otherObj.tag == "Player")
        {
            outline.SetActive(false);
            canPickup = false;
        }
    }

    void Update()
    {
        if (canPickup && pickedUp == false && Input.GetButtonDown("Interact"))
        {
            PickedUp();
        }
    }

    void PickedUp()
    {
        Destroy(packageTracker);
        destinationIsland = islandPackageManager.FindDestination(packageInfo.destination);
        receiverNPC = destinationIsland.GetComponentInChildren<IslandPickupPoint>().SpawnReceiver(packageInfo, this);

        packageInfo.PackagePickedUp();
        FindObjectOfType<Boat>().AddNewPackage(this);

        pickedUp = true;
        gameObject.SetActive(false);
    }
}