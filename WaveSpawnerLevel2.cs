using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawnerLevel2 : MonoBehaviour
{

    public Transform basicZombie;
    public Transform fastZombie;
    public Transform sumoZombie;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public int waveIndex = 0;
    private float timeBetweenEnemiesInWave = 0.6f;

    private string secondsLeft;
    public Text waveCountdowntext;

    //this will hold the arrays of each wave
    private Transform[][] waves = new Transform[10][];

    void Start()
    {
        //create the waves for level.  
        waves[0] = new Transform[1] { basicZombie };
        waves[1] = new Transform[2] { basicZombie, basicZombie };
        waves[2] = new Transform[3] { basicZombie, basicZombie, fastZombie };
        waves[3] = new Transform[3] { basicZombie, fastZombie, fastZombie };
        waves[4] = new Transform[4] { fastZombie, fastZombie, fastZombie, fastZombie };
        waves[5] = new Transform[5] { sumoZombie, basicZombie, fastZombie, basicZombie, basicZombie };
        waves[6] = new Transform[7] { fastZombie, basicZombie, fastZombie, basicZombie, sumoZombie, basicZombie, basicZombie };
        waves[7] = new Transform[8] { basicZombie, fastZombie, fastZombie, basicZombie, basicZombie, fastZombie, fastZombie, fastZombie };
        waves[8] = new Transform[9] { basicZombie, fastZombie, fastZombie, basicZombie, basicZombie, fastZombie, fastZombie, fastZombie, basicZombie };
        waves[9] = new Transform[10] { sumoZombie, fastZombie, fastZombie, sumoZombie, sumoZombie, fastZombie, basicZombie, basicZombie, fastZombie, fastZombie };

        //count enemies to know when level is beaten
        for (int i = 0; i < waves.Length; i++)
        {
            GameManager.numberOfEnemiesLeft += waves[i].Length;
        }
    }

    void Update()
    {
        if (waveIndex < 10)
        {
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves + waveIndex * timeBetweenEnemiesInWave;
            }
            countdown -= Time.deltaTime;
            secondsLeft = Mathf.Round(countdown).ToString();
            if (waveIndex == 0)
            {
                waveCountdowntext.text = "Get Ready!" + "\n\nFirst Wave\n" + secondsLeft;
            }

            else if (waveIndex != 0 && waveIndex != 10)
            {
                waveCountdowntext.text = "  Wave " + (waveIndex).ToString() + "\n\nNext Wave\n" + secondsLeft;
            }

            else
            {
                waveCountdowntext.text = "  Wave " + (waveIndex).ToString() + "\n\nLast Wave!\n" + "Survive to Win!\n";
            }
        }
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        //iterator through the array for the current wave
        for (int i = 0; i < waves[waveIndex - 1].Length; i++)
        {
            //spawn enemies in the array
            SpawnEnemy(waves[waveIndex - 1][i]);
            yield return new WaitForSeconds(timeBetweenEnemiesInWave);
        }

    }

    void SpawnEnemy(Transform enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
