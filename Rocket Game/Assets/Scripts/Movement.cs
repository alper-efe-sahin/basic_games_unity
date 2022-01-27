using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 110f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftEngineParticles;
    [SerializeField] ParticleSystem rightEngineParticles;
    AudioSource audioSource;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    } void Update()
    {
        ProcessThrust();
    }

    private void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();

        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            StopThrusting();
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();

        }
        else
        {
            StopRotating();
        }
    }

    private void StopRotating()
    {
        rightEngineParticles.Stop();
        leftEngineParticles.Stop();
    }

    private void RotateRight()
    {
        if (!rightEngineParticles.isPlaying)
        {
            rightEngineParticles.Play();
        }
        ApplyRotation(-rotationThrust);
    }

    private void RotateLeft()
    {
        if (!leftEngineParticles.isPlaying)
        {
            leftEngineParticles.Play();
        }
        ApplyRotation(rotationThrust);
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;

        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
