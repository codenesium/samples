using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractBOPostTypes : AbstractBusinessObject
        {
                public AbstractBOPostTypes()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string type)
                {
                        this.Id = id;
                        this.Type = type;
                }

                public int Id { get; private set; }

                public string Type { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e1bc58e8d94a1a601a344bcb924004b0</Hash>
</Codenesium>*/