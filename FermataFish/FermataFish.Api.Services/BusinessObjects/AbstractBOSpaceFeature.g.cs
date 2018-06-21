using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOSpaceFeature : AbstractBusinessObject
        {
                public AbstractBOSpaceFeature()
                        : base()
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
    <Hash>0bd5e34e6c0cd80d9a8ad868e42b3e94</Hash>
</Codenesium>*/