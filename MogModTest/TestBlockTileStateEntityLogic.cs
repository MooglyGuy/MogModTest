using Plukit.Base;
using Staxel.Logic;
using Staxel.Tiles;
using Staxel.TileStates;

namespace MogModTest
{
    class TestBlockTileStateEntityLogic : TileStateEntityLogic {
        public TestBlockTileStateEntityLogic(Entity entity) : base(entity)
        {
        }

        public override void PreUpdate(Timestep timestep, EntityUniverseFacade entityUniverseFacade)
        {
        }

        public override void Update(Timestep timestep, EntityUniverseFacade entityUniverseFacade)
        {
        }

        public override void PostUpdate(Timestep timestep, EntityUniverseFacade entityUniverseFacade)
        {
            entityUniverseFacade.RemoveEntity(this.Entity.Id);
        }

        public override void Construct(Blob arguments, EntityUniverseFacade entityUniverseFacade)
        {
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

        public override bool IsAtLastSavedPosition()
        {
            return true;
        }

        public override ChunkKey GetLastSavedPosition()
        {
            return new ChunkKey(Entity.Physics.Position);
        }

        public override bool IsLingering()
        {
            return false;
        }

        public override void KeepAlive()
        {
        }

        public override void BeingLookedAt(Entity entity)
        {
        }

        public override bool IsBeingLookedAt()
        {
            return false;
        }
    }
}
