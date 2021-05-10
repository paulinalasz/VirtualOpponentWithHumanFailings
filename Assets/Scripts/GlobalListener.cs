using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalListener {

    public static List<Sound> SoundsPlaying = new List<Sound>();

    public static void updateSoundsPlaying(Sound sound) {
        if (!SoundsPlaying.Contains(sound)) {
            SoundsPlaying.Add(sound);
        } else {
            removeSoundsPlaying(sound);
            SoundsPlaying.Add(sound);
        }
    }

    public static void removeSoundsPlaying(Sound sound) {
        SoundsPlaying.Remove(sound);
    }
}