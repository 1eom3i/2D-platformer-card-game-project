using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Analyzer : MonoBehaviour
{
    public static Analyzer instance;
    private DateTime start;
    private Scene current_scene;
    private string scene_name;

    void Awake()
    {
        if (Analyzer.instance == null)
        {
            Analyzer.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        start = DateTime.Now;
        current_scene = SceneManager.GetActiveScene();
        scene_name = current_scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void reach_end_point(bool result) {
        TimeSpan timeDiff = DateTime.Now - start;
        string time_to_end = timeDiff.TotalSeconds.ToString();
        int jumpRewardsCounter = CardManager.instance.getJumpRewardsCounter();
        int backRewardsCounter = CardManager.instance.getBackRewardsCounter();
        int moveRewardsCounter = CardManager.instance.getMoveRewardsCounter();
        StartCoroutine(Post_metrics_one(scene_name, time_to_end, result.ToString(), moveRewardsCounter.ToString(), backRewardsCounter.ToString(), jumpRewardsCounter.ToString()));
    }
    private IEnumerator Post_metrics_one(string name, string time, string result, string moveCounter, string BackCounter, string JumpCounter)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.124876572", name);
        form.AddField("entry.739671980", time);
        form.AddField("entry.900750274", result);
        form.AddField("entry.2126146455", moveCounter);
        form.AddField("entry.952175471", BackCounter);
        form.AddField("entry.2032207756", JumpCounter);
        using (UnityWebRequest www = UnityWebRequest.Post("https://docs.google.com/forms/u/1/d/e/1FAIpQLScFEZJp8FGKkpxBLyFUrFcc25Fbyn399S9mt6QTj1exgIvVOA/formResponse", form))
        {
            www.SetRequestHeader("Access-Control-Allow-Credentials", "true");
            www.SetRequestHeader("Access-Control-Expose-Headers", "Content-Length, Content-Encoding");
            www.SetRequestHeader("Access-Control-Allow-Headers", "Accept, X-Access-Token, X-Application-Name, X-Request-Sent-Time, Content-Type");
            www.SetRequestHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            www.SetRequestHeader("Access-Control-Allow-Origin", "*");
            yield return www.SendWebRequest();
        }
    }

    public void sendCardData(bool result, int move_count, int back_count, int jump_count, int dash_count)
    {
        StartCoroutine(Post_metrics_two(scene_name, result.ToString(), move_count.ToString(), back_count.ToString(), jump_count.ToString(), dash_count.ToString()));
    }
    private IEnumerator Post_metrics_two(string name, string result, string move_count, string back_count, string jump_count, string dash_count)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1113204870", name);
        form.AddField("entry.1048885473", move_count);
        form.AddField("entry.648606427", jump_count);
        form.AddField("entry.1238216667", back_count);
        form.AddField("entry.954460389", result);
        form.AddField("entry.153829726", dash_count);
        using (UnityWebRequest www = UnityWebRequest.Post("https://docs.google.com/forms/u/1/d/e/1FAIpQLSdm7pAuNhyB5b_Y2jsyDMeiQfzab9RJIHrXhnS90hUe4Gztug/formResponse", form))
        {
            www.SetRequestHeader("Access-Control-Allow-Credentials", "true");
            www.SetRequestHeader("Access-Control-Expose-Headers", "Content-Length, Content-Encoding");
            www.SetRequestHeader("Access-Control-Allow-Headers", "Accept, X-Access-Token, X-Application-Name, X-Request-Sent-Time, Content-Type");
            www.SetRequestHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            www.SetRequestHeader("Access-Control-Allow-Origin", "*");
            yield return www.SendWebRequest();
        }
    }
    public void sendDeathData (float x, float y, string reason)
    {
        StartCoroutine(Post_metrics_three(scene_name, x.ToString(), y.ToString(), reason));
    }

    private IEnumerator Post_metrics_three(string name, string x, string y, string reason)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.2093543086", name);
        form.AddField("entry.865735910", x);
        form.AddField("entry.569803201", y);
        form.AddField("entry.1553531762", reason);
        using (UnityWebRequest www = UnityWebRequest.Post("https://docs.google.com/forms/u/1/d/e/1FAIpQLSceRbjfNYTzoilrUa4M-z23wJHU_b63b91cAhsUgCsLeAMcCA/formResponse", form))
        {
            www.SetRequestHeader("Access-Control-Allow-Credentials", "true");
            www.SetRequestHeader("Access-Control-Expose-Headers", "Content-Length, Content-Encoding");
            www.SetRequestHeader("Access-Control-Allow-Headers", "Accept, X-Access-Token, X-Application-Name, X-Request-Sent-Time, Content-Type");
            www.SetRequestHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            www.SetRequestHeader("Access-Control-Allow-Origin", "*");
            yield return www.SendWebRequest();
        }
    }
}
