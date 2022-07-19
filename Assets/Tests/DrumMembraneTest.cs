using System;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

public class DrumMembraneTest
{
    private DrumMembrane _dm1;
    private DrumMembrane _dm2;
    private DrumMembrane _dm3;
    
    [SetUp]
    public void Setup()
    {
        var drumMembraneObject1 = new GameObject("dm1");
        drumMembraneObject1.AddComponent<SphereCollider>();
        this._dm1 = drumMembraneObject1.AddComponent<DrumMembrane>();
        
        var drumMembraneObject2 = new GameObject("dm2");
        var sc2 = drumMembraneObject2.AddComponent<SphereCollider>();
        sc2.center = new Vector3(0f, 0.45f, 0f);
        sc2.radius = 0.2f;
        this._dm2 = drumMembraneObject2.AddComponent<DrumMembrane>();
        
        var drumMembraneObject3 = new GameObject("dm3");
        var sc3 = drumMembraneObject3.AddComponent<SphereCollider>();
        sc3.center = new Vector3(-25f, 1f, -45f);
        sc3.radius = 1.45f;
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
    public void GetsNormalizedDistance()
    {
        var drum = this._dm1.GetComponent<DrumMembrane>();
        var collider = this._dm1.GetComponent<Collider>();
        var drum2 = this._dm2.GetComponent<DrumMembrane>();
        var collider2 = this._dm2.GetComponent<Collider>();
        var drum3 = this._dm3.GetComponent<DrumMembrane>();
        var collider3 = this._dm3.GetComponent<Collider>();
        
        /*Assert.True(drum.GetNormalizedDistance(new Vector2(0f, 0f)) == 0.0f);
        Assert.True(drum.GetNormalizedDistance(new Vector2(4f, 3f)) == 5f);
        Assert.True(drum.GetNormalizedDistance(new Vector2(4f, -3f)) == 5f);
        Assert.True(drum.GetNormalizedDistance(new Vector2(-4f, -3f)) == 5f);*/
        
        Assert.AreEqual(
            drum.GetNormalizedDistance(new Vector2(0f, 0f)),
            0.0f);
        Assert.AreEqual(
            drum.GetNormalizedDistance(new Vector2(0.4f, 0.3f)),
            1f);
        Assert.AreEqual(  // test value clamping
            drum.GetNormalizedDistance(new Vector2(4f, 3f)),
            1f);
        Assert.AreEqual(
            drum.GetNormalizedDistance(new Vector2(-0.4f, 0.3f)),
            1f);
        Assert.AreEqual(
            drum.GetNormalizedDistance(new Vector2(-4f, -3f)),
            1f);

        Assert.AreEqual(
            drum2.GetNormalizedDistance(new Vector2(0.1f, 0.0f)), 
            0.5f);
        /*Assert.AreEqual(
            drum2.GetNormalizedDistance(new Vector2(0.4f, 0.3f)),
            0.25f);*/

        // TODO: implement more tests...
    }
    
    [Test]
    public void SynthesizesParameters()
    {
        // TODO: implement tests...
    }
}