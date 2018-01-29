using Plukit.Base;
using Staxel;
using Staxel.Items;
using Staxel.Logic;
using Staxel.Tiles;
using Staxel.TileStates;

namespace MogModTest
{
    class TestBlockTileStateEntityLogic : TileStateEntityLogic {
        private bool _needsStore = true;
        private TileConfiguration _configuration;
        private bool _done;
        private bool _lookedAt;
        private bool _lookedAtLinger;
        private long _revision;

        public TestBlockTileStateEntityLogic(Entity entity) : base(entity)
        {
            Entity.Physics.PriorityChunkRadius(0, false);
        }

        public override void PreUpdate(Timestep timestep, EntityUniverseFacade entityUniverseFacade)
        {
            if (!_lookedAtLinger)
                _lookedAt = false;
            _lookedAtLinger = false;
        }

        public override void Update(Timestep timestep, EntityUniverseFacade entityUniverseFacade)
        {
        }

        public override void PostUpdate(Timestep timestep, EntityUniverseFacade universe)
        {
            Tile result;
            if (!universe.ReadTile(Location, TileAccessFlags.None, out result))
                return;
            if (result.Configuration != _configuration)
            {
                if (result.Configuration.CanonicalConfiguration == _configuration.CanonicalConfiguration)
                {
                    _configuration = result.Configuration;
                    _needsStore = true;
                }
                else
                {
                    universe.RemoveEntity(Entity.Id);
                }
            }
        }

        public override void Construct(Blob arguments, EntityUniverseFacade entityUniverseFacade)
        {
            _configuration = !arguments.Contains("tileMapping") ? GameContext.TileDatabase.GetTileConfiguration(arguments.GetString("tile")) : GameContext.TileMapping[(int)arguments.GetLong("tileMapping")].V;
            Location = arguments.FetchBlob("location").GetVector3I();
            Entity.Physics.Construct(arguments.FetchBlob("position").GetVector3D(), arguments.FetchBlob("velocity").GetVector3D());
        }

        public override void Bind()
        {
        }

        public override bool Interactable()
        {
            return false;
        }

        public override void Interact(Entity entity, EntityUniverseFacade facade, ControlState main, ControlState alt)
        {
        }

        public override bool CanChangeActiveItem()
        {
            return true;
        }

        public override bool IsPersistent()
        {
            return true;
        }

        public override void Store()
        {
            if (!_needsStore)
                return;
            _needsStore = false;
            ++_revision;
            _blob.SetLong("revision", _revision);
            base.Store();
            _blob.SetBool("done", _done);
            _blob.SetString("tile", _configuration.Code);
            _blob.FetchBlob("location").SetVector3I(Location);
        }

        public override void StorePersistenceData(Blob data)
        {
            base.StorePersistenceData(data);
            Blob blob = data.FetchBlob("constructData");
            blob.SetString("tile", _configuration.Code);
            blob.FetchBlob("location").SetVector3I(Location);
            blob.FetchBlob("position").SetVector3D(Entity.Physics.Position);
            blob.FetchBlob("velocity").SetVector3D(Entity.Physics.Velocity);
            data.SetBool("done", _done);
        }

        public override void Restore()
        {
            int num = (int)_blob.GetLong("revision", -1L);
            if (num == _revision)
                return;
            _revision = num;
            base.Restore();
            _done = _blob.GetBool("done");
            _configuration = GameContext.TileDatabase.GetTileConfiguration(_blob.GetString("tile"));
            Location = _blob.FetchBlob("location").GetVector3I();
        }

        public override void RestoreFromPersistedData(Blob data, EntityUniverseFacade facade)
        {
            Entity.Construct(data.GetBlob("constructData"), facade);
            base.RestoreFromPersistedData(data, facade);
            _done = data.GetBool("done");
            NeedsStore();
        }

        public override ChunkKey GetLastSavedPosition()
        {
            return new ChunkKey(Entity.Physics.Position);
        }

        public override bool IsAtLastSavedPosition()
        {
            return true;
        }

        public override bool IsLingering()
        {
            return _done;
        }

        public override void KeepAlive()
        {
            if (!_done)
                return;
            _done = false;
            _needsStore = true;
        }

        public override void BeingLookedAt(Entity entity)
        {
            KeepAlive();
            _lookedAt = true;
            _lookedAtLinger = true;
        }

        public override bool IsBeingLookedAt()
        {
            return _lookedAt;
        }

        protected void NeedsStore()
        {
            _needsStore = true;
        }
    }
}
