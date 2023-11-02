using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAreaTrig : MonoBehaviour
{
    public int materialsTotal = 15;
    private int currentCount = 0;

    public R1GameManager r1gm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HydrogenPeroxideTrigger"))
        {
            currentCount++;
            Debug.Log("Entered. Count = " + currentCount);
        }

        if (other.CompareTag("RedDyeTrigger"))
        {
            currentCount++;
            Debug.Log("Entered. Count = " + currentCount);
        }

        // if (other.CompareTag("GreenDyeTrigger"))
        // {
        //     currentCount++;
        //     Debug.Log("Entered. Count = " + currentCount);
        // }

        // if (other.CompareTag("BlueDyeTrigger"))
        // {
        //     currentCount++;
        //     Debug.Log("Entered. Count = " + currentCount);
        // }

        // if (other.CompareTag("YellowDyeTrigger"))
        // {
        //     currentCount++;
        //     Debug.Log("Entered. Count = " + currentCount);
        // }

        if (other.CompareTag("DryYeastTrigger"))
        {
            currentCount++;
            Debug.Log("Entered. Count = " + currentCount);
        }

        if (other.CompareTag("DishwashingLiquidTrigger"))
        {
            currentCount++;
            Debug.Log("Entered. Count = " + currentCount);
        }

        if (other.CompareTag("MeasuringCylinderTrigger"))
        {
            currentCount++;
            Debug.Log("Entered. Count = " + currentCount);
        }

        if (other.CompareTag("Beaker2Trigger"))
        {
            currentCount++;
            Debug.Log("Entered. Count = " + currentCount);
        }

        if (other.CompareTag("WaterCylinderTrigger"))
        {
            currentCount++;
            Debug.Log("Entered. Count = " + currentCount);
        }

        if (other.CompareTag("BeakerTrigger"))
        {
            currentCount++;
            Debug.Log("Entered. Count = " + currentCount);
        }

        if (other.CompareTag("BowlTrigger"))
        {
            currentCount++;
            Debug.Log("Entered. Count = " + currentCount);
        }

        if (currentCount >= materialsTotal)
        {
            Debug.Log("Target count reached!");
            r1gm.AllObjectsIn = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HydrogenPeroxideTrigger"))
        {
            currentCount--;
            Debug.Log("Exited. Count = " + currentCount);
        }

        if (other.CompareTag("RedDyeTrigger"))
        {
            currentCount--;
            Debug.Log("Exited. Count = " + currentCount);
        }

        if (other.CompareTag("GreenDyeTrigger"))
        {
            currentCount--;
            Debug.Log("Exited. Count = " + currentCount);
        }

        if (other.CompareTag("BlueDyeTrigger"))
        {
            currentCount--;
            Debug.Log("Exited. Count = " + currentCount);
        }

        if (other.CompareTag("YellowDyeTrigger"))
        {
            currentCount--;
            Debug.Log("Exited. Count = " + currentCount);
        }

        if (other.CompareTag("DryYeastTrigger"))
        {
            currentCount--;
            Debug.Log("Exited. Count = " + currentCount);
        }

        if (other.CompareTag("DishwashingLiquidTrigger"))
        {
            currentCount--;
            Debug.Log("Exited. Count = " + currentCount);
        }

        if (other.CompareTag("MeasuringCylinderTrigger"))
        {
            currentCount--;
            Debug.Log("Exited. Count = " + currentCount);
        }

        if (other.CompareTag("Beaker2Trigger"))
        {
            currentCount--;
            Debug.Log("Exited. Count = " + currentCount);
        }

        if (other.CompareTag("WaterCylinderTrigger"))
        {
            currentCount--;
            Debug.Log("Exited. Count = " + currentCount);
        }

        if (other.CompareTag("BeakerTrigger"))
        {
            currentCount--;
            Debug.Log("Exited. Count = " + currentCount);
        }

        if (other.CompareTag("BowlTrigger"))
        {
            currentCount--;
            Debug.Log("Exited. Count = " + currentCount);
        }
    }

}
