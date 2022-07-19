using UnityEngine;

public class Beat
{
    private AudioClip[] _clips;
    private float[] _volumes;
    
    public Beat(AudioClip[] clips, float[] volumes)
    {
        this._clips = clips;
        this._volumes = volumes;
    }

    public float getAmplitude(float timeStamp)
    {
        return 0.0f;
    }
    
    public float getFrequency(float timeStamp)
    {
        return 0.0f;
    }
    
    public float getWavelength(float timeStamp)
    {
        return 0.0f;
    }
}
[RequireComponent(typeof(Collider))]
public class DrumMembrane : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] positionClips;
    [SerializeField]
    private AudioClip[] forceClips;
    
    [SerializeField]
    private float[] maxPointOnRadius;
    [SerializeField]
    private float[] minDistanceFromPoint;
    
    [SerializeField]
    private float midPowerThreshold;
    [SerializeField]
    private float highPowerThreshold;
    
    public Beat CreateBeatFromHit(float distanceFromCenter)
    {
        var parameters = this.SynthesizeParameters(distanceFromCenter);
        var newBeat = new Beat(parameters.Item1, parameters.Item2);
        return newBeat;
    }

    public Beat CreateBeatFromHit(Vector2 position)
    {
        var distance = this.GetNormalizedDistance(position);
        return this.CreateBeatFromHit(distance);
    }

    public (AudioClip[], float[]) SynthesizeParameters(float distanceFromCenter)
    {
        // TODO: implement this...
        return (new AudioClip[]{ this.positionClips[0] }, new float[] { 0.0f });  // placeholder
    }

    public float GetNormalizedDistance(Vector2 position)
    {
        // TODO: handle conversion from world space to local space somehow maybe...

        var localCollider = this.gameObject.GetComponent<Collider>();
        var center = localCollider.bounds.center;
        //Debug.Log(center.x + ", " + center.z + " & " + position.x + ", " + position.y);
        
        // find distance in standard measurement units, assuming the implicit conversion from vec3 to vec2 functions as expected...
        var distance = Mathf.Abs(Vector2.Distance(new Vector2(center.x, center.z), position));

        // convert to normalized distance and return
        var width = localCollider.bounds.size.x;  // assuming a regular circle
        var distanceNormalized = distance / (width / 2);
        return distanceNormalized <= 1 ? distanceNormalized : 1;
    }
}
