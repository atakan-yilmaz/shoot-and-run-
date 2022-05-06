using UnityEngine;


namespace shootandRun1.Controllers
{
    public class BulletFxController : MonoBehaviour
    {
        [SerializeField] float _maxLifeTime = 5f;
        [SerializeField] float _moveSpeed = 100f;

        Rigidbody _rigidBody;
        ParticleSystem _particleSystem;

        float _currentLifeTime = 0f;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _particleSystem = GetComponentInChildren<ParticleSystem>();
        }

        void Start()
        {
            _particleSystem.Play();
        }

        void Update()
        {
            _currentLifeTime += Time.deltaTime;

            if (_currentLifeTime > _maxLifeTime)
            {
                Destroy(this.gameObject);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            Destroy(this.gameObject);
        }

        public void SetDirection(Vector3 direction)
        {
            _rigidBody.velocity = direction * _moveSpeed;
        }
    }
}
