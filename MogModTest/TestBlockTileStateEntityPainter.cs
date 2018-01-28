using Plukit.Base;
using Staxel;
using Staxel.Client;
using Staxel.Draw;
using Staxel.Effects;
using Staxel.Logic;
using Staxel.Rendering;

namespace MogModTest
{
    class TestBlockTileStateEntityPainter : EntityPainter
    {
        protected override void Dispose(bool disposing)
        {
        }

        public override void RenderUpdate(Timestep timestep, Entity entity, AvatarController avatarController, EntityUniverseFacade facade,
            int updateSteps)
        {
        }

        public override void ClientUpdate(Timestep timestep, Entity entity, AvatarController avatarController, EntityUniverseFacade facade)
        {
        }

        public override void ClientPostUpdate(Timestep timestep, Entity entity, AvatarController avatarController, EntityUniverseFacade facade)
        {
        }

        public override void BeforeRender(DeviceContext graphics, Vector3D renderOrigin, Entity entity, AvatarController avatarController,
            Timestep renderTimestep)
        {
        }

        public override void Render(DeviceContext graphics, Matrix4F matrix, Vector3D renderOrigin, Entity entity,
            AvatarController avatarController, Timestep renderTimestep, RenderMode renderMode)
        {
        }

        public override void StartEmote(Entity entity, Timestep renderTimestep, EmoteConfiguration emote)
        {
        }
    }
}
