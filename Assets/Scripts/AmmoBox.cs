using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private GameObject _gun;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GunScript gunScript = _gun.GetComponent<GunScript>();
            if (gunScript != null)
            {
                gunScript.BagAmmo += 10;
                Debug.Log("AmmoBox OnTriggerEnter: ����� ������ �������. ����������� BagAmmo: " + gunScript.BagAmmo);
            }
            else
            {
                Debug.LogError("AmmoBox OnTriggerEnter: �� ������ GunScript �� ������� _gun.");
            }

            Destroy(gameObject);
        }
    }
}
    