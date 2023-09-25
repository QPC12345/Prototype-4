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
    private float timer = 0.0f;
    private AudioSource audio;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
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
        if (timer >= interval) {
            int currInterest = getInterest();
            balance+=currInterest;
            TMP.text = "Balance: $" + balance + " | Interest: $" + currInterest + "/sec";
            timer = 0.0f;
        }
        else {
            timer+=Time.deltaTime;
        }
    }

    public void updateArray(int y, int x, int level) {
        grid[y,x] = level;
    }

    public int getBalance() {
        return balance;
    }

    public void subtractFromBalance(int val) {
        balance-=val;
        TMP.text = "Balance: $" + balance + " | Interest: $" + getInterest() + "/sec";
        audio.PlayOneShot(clip);
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
}
