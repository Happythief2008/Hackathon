using UnityEngine;
using System.Collections;

public class audio_manager : MonoBehaviour
{
    public static audio_manager Instance;

    [Header("BGM")]
    public AudioClip bgmClip;
    public float bgmVolume = 0.5f;
    private AudioSource bgmSource;

    [Header("SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume = 1f;
    public int sfxChannels = 5;
    private AudioSource[] sfxSources;
    private int sfxIndex = 0;

    public enum SfxType
    {
        Click,
        Jump,
        Hit,
        Explosion
    }

    void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitAudio();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitAudio()
    {
        // BGM 플레이어 생성
        GameObject bgmObj = new GameObject("BGM_Player");
        bgmObj.transform.SetParent(transform);
        bgmSource = bgmObj.AddComponent<AudioSource>();
        bgmSource.clip = bgmClip;
        bgmSource.loop = true;
        bgmSource.volume = bgmVolume;
        bgmSource.playOnAwake = false;
        bgmSource.Play();

        // SFX 플레이어 풀 생성
        sfxSources = new AudioSource[sfxChannels];
        for (int i = 0; i < sfxChannels; i++)
        {
            GameObject sfxObj = new GameObject($"SFX_Player_{i}");
            sfxObj.transform.SetParent(transform);
            sfxSources[i] = sfxObj.AddComponent<AudioSource>();
            sfxSources[i].playOnAwake = false;
            sfxSources[i].volume = sfxVolume;
        }
    }

    /// <summary>
    /// 효과음 재생
    /// </summary>
    /// <param name="type">enum으로 정의한 SFX</param>
    /// <param name="customVolume">기본 볼륨 사용 시 -1</param>
    /// <param name="playTime">재생 시간 제한. 0이면 전체</param>
    /// <param name="loop">반복 여부</param>
    public void PlaySfx(SfxType type, float customVolume, float playTime, bool loop)
    {
        int index = (int)type;
        if (index < 0 || index >= sfxClips.Length) return;

        // 다음 사용 가능한 채널
        AudioSource sfx = sfxSources[sfxIndex];
        sfxIndex = (sfxIndex + 1) % sfxChannels;

        sfx.clip = sfxClips[index];
        sfx.volume = customVolume >= 0 ? customVolume : sfxVolume;
        sfx.loop = loop;
        sfx.Play();

        // 일정 시간 후 정지
        if (!loop && playTime > 0f)
        {
            StartCoroutine(StopAfterTime(sfx, playTime));
        }
    }

    IEnumerator StopAfterTime(AudioSource source, float time)
    {
        yield return new WaitForSeconds(time);
        if (source.isPlaying)
        {
            source.Stop();
        }
    }

    /// <summary>
    /// BGM 일시정지/재생 제어
    /// </summary>
    public void PauseBgm(bool pause)
    {
        if (pause) bgmSource.Pause();
        else bgmSource.UnPause();
    }

    public void ChangeBgm(AudioClip newClip)
    {
        if (bgmSource.clip != newClip)
        {
            bgmSource.Stop();
            bgmSource.clip = newClip;
            bgmSource.Play();
        }
    }
}

/*사용법 

SfxType에 사용할 소리 입력(이름 달라도 상관 없음)
audio_manager.Instance.PlaySfx(audio_manager.SfxType.원하는 타입,볼륨,트는 시간,반복);

*/