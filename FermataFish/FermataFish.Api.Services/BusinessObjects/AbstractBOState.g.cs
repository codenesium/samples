using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractBOState: AbstractBusinessObject
        {
                public AbstractBOState() : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a232da1a2783b74c87b9d1660676ac79</Hash>
</Codenesium>*/