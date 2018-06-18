using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOSpaceFeature: AbstractBusinessObject
        {
                public AbstractBOSpaceFeature() : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>a11bf681ec7090fc3b977bc790932c5e</Hash>
</Codenesium>*/