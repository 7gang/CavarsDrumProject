using NUnit.Framework;
using UnityEngine;

public class DrumMembraneTest
{
    private DrumMembrane _dm1;
    private DrumMembrane _dm2;
    private DrumMembrane _dm3;
    
    [SetUp]
    public void Setup()
    {
        var drumMembraneObject1 = new GameObject("dm1");
        this._dm1 = drumMembraneObject1.AddComponent<DrumMembrane>();
        
        var drumMembraneObject2 = new GameObject("dm2");
        drumMembraneObject2.transform.position = new Vector3(0f, 0.45f, 0f);
        drumMembraneObject2.transform.Rotate(new Vector3(1f, 0f, 0f), 90f);
        drumMembraneObject2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        this._dm2 = drumMembraneObject2.AddComponent<DrumMembrane>();
        
        var drumMembraneObject3 = new GameObject("dm3");
        drumMembraneObject3.transform.Rotate(new Vector3(1, 0, 0), 45f);
        drumMembraneObject3.transform.Rotate(new Vector3(0, 1, 0), 45f);
        drumMembraneObject3.transform.position = new Vector3(-25f, 1f, -45f);
        drumMembraneObject3.transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
        this._dm3 = drumMembraneObject3.AddComponent<DrumMembrane>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(this._dm1);
        Object.DestroyImmediate(this._dm2);
        Object.DestroyImmediate(this._dm3);
    }

    [Test]
    public void ConvertsFromPositionToDistance()
    {
        var drum = this._dm1.GetComponent<DrumMembrane>();
        Assert.True(drum.ConvertFromPositionToDistance(new Vector2(0f, 0f)) == 0.0f);
        Assert.True(drum.ConvertFromPositionToDistance(new Vector2(4f, 3f)) == 5f);
        Assert.True(drum.ConvertFromPositionToDistance(new Vector2(4f, -3f)) == 5f);
        Assert.True(drum.ConvertFromPositionToDistance(new Vector2(-4f, -3f)) == 5f);


        // TODO: implement more tests...
    }
    
    [Test]
    public void SynthesizesParameters()
    {
        // TODO: implement tests...
    }
}