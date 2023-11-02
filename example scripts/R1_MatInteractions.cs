using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R1_MatInteractions : MonoBehaviour
{
    public GameObject GameManager;
    public static R1GameManager gm;
    public GameObject fill;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetComponent<R1GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BeakerTrigger"))
        {
            if (tag == "MeasuringCylinderTrigger")
            {
                FillController otherFill = collision.gameObject.GetComponent<FillController>();
                otherFill.fill.SetActive(true);
                gm.MeasuringCylinderInBeaker1 = true;
                fill.SetActive(false);
                gm.audioClip1_6b = true;
            }
            else if(tag == "DishwashingLiquidTrigger")
            {
                FillController otherFill = collision.gameObject.GetComponent<FillController>();
                gm.DishLiqInBeaker1 = true;
                otherFill.fill.SetActive(true);
                gm.audioClip1_7b = true;
            }
        }
        else if (collision.gameObject.CompareTag("Beaker2Trigger"))
        {
            if(tag == "Beaker1" && gm.beaker1complete == true)
            {
                FillController otherFill = collision.gameObject.GetComponent<FillController>();
                otherFill.fill.SetActive(true);
                gm.RedBeaker2InBeaker1 = true;
                fill.SetActive(false);
                gm.audioClip1_11b = true;
            }
            else if(tag == "DryYeastTrigger")
            {
                FillController otherFill = collision.gameObject.GetComponent<FillController>();
                otherFill.fill.SetActive(true);
                gm.RedYeastInBeaker2 = true;
                gm.audioClip1_10b = true;
            }
            else if (tag == "WaterCylinderTrigger")
            {
                FillController otherFill = collision.gameObject.GetComponent<FillController>();
                otherFill.fill.SetActive(true);
                gm.RedWaterCylInBeaker2 = true;
                fill.SetActive(false);
                gm.audioClip1_9b = true;
            }
        }
        else if (tag == "bowl" && gm.beaker1complete && gm.beaker2complete)
        {
            gm.reactionComplete = true;
        }
        //set progression flags
        if (gm.MeasuringCylinderInBeaker1 && gm.DishLiqInBeaker1)
        {
            gm.beaker1complete = true;
        }
        if (gm.RedBeaker2InBeaker1 && gm.RedYeastInBeaker2 && gm.RedWaterCylInBeaker2)
        {
            gm.beaker2complete = true;
        }
    }
    void Step2()
    {

    }
}
