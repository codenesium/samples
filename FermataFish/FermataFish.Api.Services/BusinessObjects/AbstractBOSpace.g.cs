using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOSpace : AbstractBusinessObject
        {
                public AbstractBOSpace()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>06338a70061f192aa57e4452b4cac3e3</Hash>
</Codenesium>*/