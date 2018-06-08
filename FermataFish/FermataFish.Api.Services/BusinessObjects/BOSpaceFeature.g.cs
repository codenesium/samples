using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOSpaceFeature: AbstractBusinessObject
        {
                public BOSpaceFeature() : base()
                {
                }

                public void SetProperties(int id,
                                          string name,
                                          int studioId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.StudioId = studioId;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int StudioId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ab3e6626f58341880915bff6a2654ef7</Hash>
</Codenesium>*/