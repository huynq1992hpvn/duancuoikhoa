using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Scale
{
    float maxScale = 4f;
    float minScale = 1.12f;
    


    public Vector3 CalculateHead(Gatetype gateType, int gateValue, Transform headTransform)
        {
        float changeSize = (float)gateValue / 100f;
        float newXScale;
        float newYScale;
        float newZScale;
        switch(gateType)
        { case Gatetype.fatterType:
                newXScale = headTransform.localScale.x + changeSize;
                newYScale = headTransform.localScale.y + changeSize;
                newZScale = headTransform.localScale.z;
                if (newXScale > maxScale)
                {
                    newXScale = maxScale;
                }
                if (newYScale > maxScale)
                {
                    newYScale = maxScale;
                }
                return new Vector3(newXScale, newYScale, newZScale);
                
                
            case Gatetype.thinnerType:
                newXScale = headTransform.localScale.x - changeSize;
                newYScale = headTransform.localScale.y - changeSize;
                newZScale = headTransform.localScale.z;
                if (newXScale < minScale)
                {
                    newXScale = minScale;
                }
                if (newYScale < minScale)
                {
                    newYScale = minScale;
                }
                return new Vector3(newXScale, newYScale, newZScale);
            case Gatetype.shorterType:
                newXScale = headTransform.localScale.x;
                newYScale = headTransform.localScale.y;
                newZScale = headTransform.localScale.z - changeSize;
                if (newZScale > maxScale)
                {
                    newZScale = maxScale;
                }
                return new Vector3(newXScale, newYScale, newZScale);
            case Gatetype.tallerType:
                newXScale = headTransform.localScale.x;
                newYScale = headTransform.localScale.y;
                newZScale = headTransform.localScale.z + changeSize;
                if (newZScale < minScale)
                {
                    newZScale = minScale;
                }
                return new Vector3(newXScale, newYScale, newZScale);

            default:
                return new Vector3(minScale,minScale,minScale);
                

        }
}
}
