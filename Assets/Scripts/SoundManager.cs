using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    public Slider volumeSlider;

    void Start() {
        
    }

    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value;
    }

}
