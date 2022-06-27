using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace TestEcsZenject
{
    public sealed class ECSStarter : MonoBehaviour
    {
        [SerializeField] private GameUI gameUI;
        
        private EcsWorld _world;
        private EcsSystems _systems;

        [Inject] private GameBinds _gameBinds;
        [Inject] private SpawnTransforms _spawnTransforms;

        // Start is called before the first frame update
        private void Start()
        {
            gameUI.RestartGameAction += RestartWorld;
            StartWorld();          
        }

        private void AddInjections()
        {
            _systems.Inject(_gameBinds);
            _systems.Inject(_spawnTransforms);
            _systems.Inject(gameUI);
        }

        private void AddSystems()
        {
            _systems.Add(new PlayerInitSystem());
            _systems.Add(new PlayerInputSystem());
            _systems.Add(new PlayerMovementSystem());
            _systems.Add(new EnemySpawnSystem());
            _systems.Add(new EnemyMoveSystem());
            _systems.Add(new EnemyDestroySystem());
            _systems.Add(new ProjectileWeaponSystem());
            _systems.Add(new WeaponSwitchSystem());
            _systems.Add(new ProjectileMoveSystem());
            _systems.Add(new BulletDespawnSystem()); 
            _systems.Add(new CollisionHandleSystem());
            _systems.Add(new EntityDestroySystem());
            _systems.Add(new ScoreSystem());
            _systems.Add(new GameOverSystem());
            _systems.Add(new DestroySystem());
        }

        // Update is called once per frame
        private void Update()
        {
            _systems?.Run();
        }

        private void StartWorld()
        {
            InitUI();
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            AddInjections();
            AddSystems();

            _systems.ConvertScene();

            _systems.Init();
        }

        private void RestartWorld()
        {
            ClearWorld();
            StartWorld();
        }

        private void ClearWorld()
        {
            if (_systems == null)
                return;

            _systems.Destroy();
            _systems = null;

            _world.Destroy();
            _world = null;
        }

        private void InitUI()
        {
            gameUI.SetHealth(_gameBinds.GameSettings.PlayerHealth);
            gameUI.SetScore(0);
            gameUI.ShowGameEnd(false);
            gameUI.ShowUI(true);
        }

        private void OnDestroy()
        {
            ClearWorld();
            gameUI.RestartGameAction -= RestartWorld;
        }
    }
}