using Plukit.Base;
using Staxel.Logic;
using Staxel.Tiles;

namespace MogModTest {
    class TestBlockTileStateEntityBuilder : IEntityPainterBuilder, IEntityLogicBuilder {
        public string Kind { get { return KindCode; } }
        public static string KindCode { get { return "mods.testBlock.tileState.testBlock"; } }

        EntityPainter IEntityPainterBuilder.Instance()
        {
            return (EntityPainter)new TestBlockTileStateEntityPainter();
        }

        EntityLogic IEntityLogicBuilder.Instance(Entity entity, bool server)
        {
            return (EntityLogic)new TestBlockTileStateEntityLogic(entity);
        }

        void IEntityLogicBuilder.Load()
        {
        }

        void IEntityPainterBuilder.Load()
        {
        }

        public static Entity Spawn(EntityUniverseFacade facade, Tile tile, Vector3I location)
        {
            var entity = new Entity(facade.AllocateNewEntityId(), false, KindCode, true);
            var blob = BlobAllocator.Blob(true);
            blob.SetString(nameof(tile), tile.Configuration.Code);
            blob.FetchBlob(nameof(location)).SetVector3I(location);
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
