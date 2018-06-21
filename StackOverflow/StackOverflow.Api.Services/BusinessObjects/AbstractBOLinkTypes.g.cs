using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractBOLinkTypes : AbstractBusinessObject
        {
                public AbstractBOLinkTypes()
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
    <Hash>78e70342bfa601a191ba5fae0467b729</Hash>
</Codenesium>*/