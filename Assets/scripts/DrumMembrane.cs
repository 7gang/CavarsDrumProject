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
        var distance = this.ConvertFromPositionToDistance(position);
        return this.CreateBeatFromHit(distance);
    }

    public (AudioClip[], float[]) SynthesizeParameters(float distanceFromCenter)
    {
        // TODO: implement this...
        return (new AudioClip[]{ this.positionClips[0] }, new float[] { 0.0f });  // placeholder
    }

    public float ConvertFromPositionToDistance(Vector2 position)
    {
        // TODO: implement this...
        return 0.0f;  // placeholder
    }
}
