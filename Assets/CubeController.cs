using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
    //キューブの移動速度
    private float speed = -0.2f;

    //消滅位置
    private float deadLine = -10;


    //AudioSourceコンポーネントを入れる
    AudioSource audioSource;
    //AudioClipを入れる
    public AudioClip audioClip;

    //Cubeの積み重なり判定
    public bool isPlayed = false;


    // Use this for initialization
    void Start () {
        //AudioSourceのコンポーネントを取得する
        this.audioSource = gameObject.GetComponent<AudioSource>();
        //AudioClipを設定
        audioSource.clip = audioClip;
    }
	
	// Update is called once per frame
	void Update () {
        //キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        //画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
	}


    
    //課題
    //落下してくるCubeが地面かCubeに接触した瞬間に効果音を鳴らす
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            //Cubeが接触したら音を鳴らす
            audioSource.PlayOneShot(audioClip);

            //1度鳴らしたら完了にする
            this.isPlayed = true;

            //Debug.Log("groundに接触");
        }
        if (collision.gameObject.tag == "CubePrefab" && isPlayed == false)
        {
            //Cubeが接触したら音を鳴らす
            audioSource.PlayOneShot(audioClip);

            //1度鳴らしたら完了にする
            this.isPlayed = true;

            //Debug.Log("CubePrefabに接触");
        }
    }
}
