using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class House : MonoBehaviour
{
    private int level = 0;
    public int upgradePrice = 50;
    public Bank bank;
    public int x;
    public int y;
    public TextMeshPro TMP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked() && bank.getBalance() >= level * upgradePrice) {
            level++;
            bank.updateArray(y, x, level);
            bank.subtractFromBalance(level * upgradePrice);
            TMP.text = level + "";
        }
    }

    private bool isClicked() {
        bool ret = false;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = GetComponent<Collider2D>();
            ret = (collider != null && collider.OverlapPoint(mousePosition));
        }
        return ret;
    }
}
