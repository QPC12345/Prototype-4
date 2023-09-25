using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    private int balance = 50;
    public int interest = 10;
    public float interval = 1.0f;
    private int[,] grid = new int[3, 7];
    public TextMeshPro TMP;
    // Start is called before the first frame update
    void Start()
    {
        TMP.text = "Balance: $50 | Interest: $0/sec";
        for(int y = 0; y < 3; y++) {
            for(int x = 0; x < 7; x++) {
                grid[y,x] = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int currInterest = getInterest();
        balance+=currInterest;
        TMP.text = "Balance: $" + balance + " | Interest: $" + currInterest + "/sec";
        StartCoroutine(Wait(interval));
    }

    public void updateArray(int y, int x, int level) {
        grid[y,x] = level;
    }

    public int getBalance() {
        return balance;
    }

    public void subtractFromBalance(int val) {
        balance-=val;
    }

    public int getInterest() {
        int sum = 0;
        for(int y = 0; y < 3; y++) {
            for(int x = 0; x < 7; x++) {
                sum+= grid[y,x] * interest;
            }
        }
        return sum;
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
