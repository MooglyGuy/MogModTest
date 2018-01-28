using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plukit.Base;
using Staxel.Core;
using Staxel.Items;
using Staxel.Logic;
using Staxel.Tiles;

namespace MogModTest
{
    sealed class TestBlockComponentBuilder : IComponentBuilder
    {
        public string Kind()
        {
            return "testBlock";
        }

        public object Instance(Blob config)
        {
            return new TestBlockComponent(config);
        }

        public sealed class TestBlockComponent
        {
            public Vector2I Distance { get; private set; }
            public Vector3I Offset { get; private set; }
            public int CheckTime { get; private set; }
            public int RandomCheckTime { get; private set; }
            public bool IsCurved { get; private set; }

            public TestBlockComponent(Blob config)
            {
                Distance = config.Contains("distance") ? config.GetBlob("distance").GetVector2I() : new Vector2I(2, 2);
                Offset = config.Contains("offset") ? config.GetBlob("offset").GetVector3I() : new Vector3I(0, -1, 0);
                CheckTime = (int)(config.GetDouble("checkTime", 5) * 1000000);
                RandomCheckTime = (int)(config.GetDouble("randomCheckTime", 2.5) * 1000000);
                IsCurved = config.GetBool("isCurved", false);
            }
        }
    }
}
