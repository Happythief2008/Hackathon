using System;
using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public Sound[] Sounds;
    public AudioSource[] _tracks;
    public string PlayingMusic;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 변경 시에도 유지
        }
        else
        {
            Destroy(gameObject); // 중복 방지
            return;
        }
    }

    public void PlayToDist(string musicId, Vector3 originPos, Vector3 targetPos, float distance, float pitch = 0)
    {
        if (Vector2.Distance(originPos, new Vector2(targetPos.x, targetPos.y)) <= distance)
        {
            Play(musicId, pitch);
        }
    }

    public void Play(string musicId, float pitch = 0)
    {
        // 현재 배경음과 동일하면 다시 재생하지 않음
        if (PlayingMusic == musicId) return;

        Sound sound = Array.Find(Sounds, v => v.id == musicId);
        if (sound == null) return;

        StartCoroutine(OnPlay(sound, pitch));
    }

    public void Stop(int track)
    {
        _tracks[track - 1].Stop();
        if (track == 4) // 배경음 트랙이라면 초기화
        {
            PlayingMusic = null;
        }
    }

    public void Pause(int track)
    {
        _tracks[track - 1].Pause();
    }

    public void UnPause(int track)
    {
        if (_tracks[track - 1]) _tracks[track - 1].UnPause();
    }

    public IEnumerator OnPlay(Sound sound, float pitch)
    {
        if (sound.track == 4) // 배경음 전용 트랙
        {
            if (PlayingMusic != null && PlayingMusic == sound.id) yield break;
            PlayingMusic = sound.id;
        }

        AudioSource _audio = _tracks[sound.track - 1];

        if (sound.audioIn)
        {
            _audio.clip = sound.audioIn;
            _audio.loop = false;
            _audio.volume = sound.volume;
            _audio.pitch = pitch != 0 ? pitch : sound.pitch;
            _audio.time = sound.startTime;

            _audio.Play();

            while (_audio.isPlaying)
            {
                yield return new WaitForSecondsRealtime(0.01f);
            }

            _audio.clip = sound.audio;
            _audio.Play();
            _audio.loop = sound.loop;
        }
        else
        {
            _audio.clip = sound.audio;
            _audio.loop = sound.loop;
            _audio.volume = sound.volume;
            _audio.pitch = pitch != 0 ? pitch : sound.pitch;
            _audio.time = sound.startTime;
            _audio.Play();
        }
    }
}