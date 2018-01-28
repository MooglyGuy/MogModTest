using Plukit.Base;
using Staxel.Items;
using Staxel.Logic;
using Staxel.Tiles;
using Staxel.TileStates;

namespace MogModTest
{
    class TestBlockTileStateBuilder : ITileStateBuilder
    {
        public void Dispose() { }
        public void Load() { }

        public string Kind()
        {
            return "mods.testBlock.tileState.testBlock";
        }

        public Entity Instance(Vector3I location, Tile tile, Universe universe)
        {
            return TestBlockTileStateEntityBuilder.Spawn((EntityUniverseFacade) universe, tile, location);
        }
    }
}
