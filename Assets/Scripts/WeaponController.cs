using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject[] weapons;

    public Transform armAnchor;
    public Transform weaponAnchor;
    private GameObject selectedWeapon;

    private void Start()
    {
        selectWeapon(weapons[0]);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject newSelectedWeapon = null;
        if (Input.GetButtonUp("Switch 1"))
        {
            selectWeapon(weapons[0]);
        }
        else if (Input.GetButtonUp("Switch 2"))
        {
            selectWeapon(weapons[1]);
        }


        Vector2 from = armAnchor.position;
        Vector2 to = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = new Vector2(from.x - to.x, from.y - to.y);
        armAnchor.transform.right = -direction;

        // TODO Figure out the Quaternion values for performance gain
        var zAngle = armAnchor.rotation.eulerAngles.z;
        if (zAngle > 90 && zAngle < 270)
        {
            flip();
        }
    }

    private void flip()
    {
        armAnchor.Rotate(180f, 0f, 0f);
    }

    private void selectWeapon(GameObject weapon)
    {
        if (selectedWeapon)
        {
            Destroy(selectedWeapon);
        }

        selectedWeapon = Instantiate(weapon, weaponAnchor, false);
        selectedWeapon.transform.localPosition = Vector3.zero;
    }
}