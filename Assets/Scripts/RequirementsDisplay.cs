using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequirementsDisplay : MonoBehaviour
{
    public ResourceModification resourceModifications;
    public List<Text> text;
    private void Awake()
    {
        resourceModifications = gameObject.GetComponent<ResourceModification>();
    }
    private void Update()
    {
        text[0].text = resourceModifications.ResourceUse[0].ToString();
        text[1].text = resourceModifications.ResourceUse[1].ToString();
        text[2].text = resourceModifications.ResourceUse[2].ToString();
    }
}
