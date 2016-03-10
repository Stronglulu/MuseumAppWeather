using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour
{
    public GameObject overlayObject;
    protected GameObject progressBar;
    private TextMesh text;

    public float loadTime;
    protected float delayTime = 1.5f;
    protected float timer = 0, scale;

    private CardboardHead head;
    private Overlay overlay;
    protected float t = 0; // time spent in scene

    void Start()
    {
        head = Camera.main.GetComponent<StereoController>().Head;
        //overlay = overlayObject.GetComponent<Overlay>();
        progressBar = transform.parent.FindChild("Bar Progress Pivot").gameObject;
        text = transform.parent.FindChild("Text").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update time.
        t += Time.deltaTime;
        RaycastHit hit;
        bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);

        if (IsActive())
        {
            text.text = "Replay";
        }

        if (isLookedAt && IsActive())
        {
            scale = (5f / loadTime) * timer;
            progressBar.transform.localScale = new Vector3(scale, 0.01f, 1);
            timer += Time.deltaTime;

            if (timer > loadTime)
            {
                progressBar.transform.localScale = new Vector3(0, 0.01f, 1);
                timer = 0;
                t = 0;
                text.text = "LookUp";

                //overlay.t = 0;
                Museum.Log(Time.time, "replay_extending");
            }
        }
        else
        {
            progressBar.transform.localScale = new Vector3(0, 0.01f, 1);
            timer = 0;
        }
    }

    public virtual bool IsActive()
    {
        return t > delayTime;
    }
}
