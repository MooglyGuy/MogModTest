using Plukit.Base;
using Staxel.Logic;
using Staxel.Tiles;

namespace MogModTest {
    class TestBlockTileStateEntityBuilder : IEntityPainterBuilder, IEntityLogicBuilder {
        public string Kind { get { return KindCode; } }
        public static string KindCode { get { return "mods.testBlock.tileState.testBlock"; } }

        public EntityPainter Instance()
        {
            return new TestBlockTileStateEntityPainter();
        }

        public EntityLogic Instance(Entity entity, bool server)
        {
            return new TestBlockTileStateEntityLogic(entity);
        }

        void IEntityLogicBuilder.Load()
        {
        }

        void IEntityPainterBuilder.Load()
        {
        }

        public static Entity Spawn(EntityUniverseFacade facade, Tile tile, Vector3I location)
        {
            var spawnRecord = facade.AllocateNewEntityId();
            var entity = new Entity(spawnRecord, false, KindCode, true);
            var blob = BlobAllocator.Blob(true);
            blob.SetString("tile", tile.Configuration.Code);
            blob.FetchBlob("location").SetVector3I(location);
            blob.SetLong("variant", tile.Variant());
            blob.FetchBlob("position").SetVector3D(location.ToTileCenterVector3D());
            blob.FetchBlob("velocity").SetVector3D(Vector3D.Zero);
            entity.Construct(blob, facade);
            Blob.Deallocate(ref blob);
            facade.AddEntity(entity);
            return entity;
        }
    }
}
