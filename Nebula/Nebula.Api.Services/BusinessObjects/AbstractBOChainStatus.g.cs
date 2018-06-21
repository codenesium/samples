using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractBOChainStatus : AbstractBusinessObject
        {
                public AbstractBOChainStatus()
                        : base()
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
    <Hash>8c2feb2125a6e367c1a90bb98774d383</Hash>
</Codenesium>*/