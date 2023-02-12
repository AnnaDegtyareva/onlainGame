using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public float speed;
    public int score;
    private Rigidbody2D rb;
    private PhotonView pv;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pv = GetComponent<PhotonView>();    
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Eat")
        {
            score++;
            transform.localScale = Vector3.one *(1f+(score/100f));
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Player")
        {
            pv.RPC("TryToKill", collision.GetComponent<PhotonView>().Owner, score, collision.GetComponent<PhotonView>().Owner);
        }
    }

    [PunRPC]
    public void TryToKill(int other_score, Photon.Realtime.Player player)
    {
        if(other_score >= score * 1.1f)
        {
            pv.RPC("AddScore", player, score/3);
        }
    }

    [PunRPC]
    public void AddScore(int _score)
    {
        score += _score;
    }

    
}
