using UnityEngine;

public class TankPlacement : MonoBehaviour
{
    public GameObject tankPrefab;
    private bool isOccupied = false;

    void OnMouseDown()
    {
        if (!isOccupied)
        {
            GameObject newTank = Instantiate(
                tankPrefab,
                transform.position,
                Quaternion.identity
            );

            isOccupied = true;
            gameObject.SetActive(false);
        }
    }
}