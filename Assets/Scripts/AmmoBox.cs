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
                Debug.Log("AmmoBox OnTriggerEnter: Игрок собрал патроны. Обновленное BagAmmo: " + gunScript.BagAmmo);
            }
            else
            {
                Debug.LogError("AmmoBox OnTriggerEnter: Не найден GunScript на объекте _gun.");
            }

            Destroy(gameObject);
        }
    }
}
    