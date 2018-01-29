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
            public Vector3I Offset { get; private set; }

            public TestBlockComponent(Blob config)
            {
                Offset = config.Contains("offset") ? config.GetBlob("offset").GetVector3I() : new Vector3I(0, -1, 0);
            }
        }
    }
}
