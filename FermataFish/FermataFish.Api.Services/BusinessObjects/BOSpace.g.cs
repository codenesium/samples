using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOSpace: AbstractBusinessObject
        {
                public BOSpace() : base()
                {
                }

                public void SetProperties(int id,
                                          string description,
                                          string name,
                                          int studioId)
                {
                        this.Description = description;
                        this.Id = id;
                        this.Name = name;
                        this.StudioId = studioId;
                }

                public string Description { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int StudioId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>292f4292fd93a285613f28dc807c4195</Hash>
</Codenesium>*/