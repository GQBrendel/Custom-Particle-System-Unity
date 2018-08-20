using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    int trackPointIds;
    public bool shouldStartAllTracks;
    public List<GameObject> tracks;

    void Start()
    {
        trackPointIds = 0;

    }
    public void setTrackId(idKeeper trackPoint)
    {
        trackPoint.id = trackPointIds;
        trackPointIds++;
    }
}
