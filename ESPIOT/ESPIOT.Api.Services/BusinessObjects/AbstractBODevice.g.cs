using Codenesium.DataConversionExtensions;
using System;

namespace ESPIOTNS.Api.Services
{
        public abstract class AbstractBODevice : AbstractBusinessObject
        {
                public AbstractBODevice()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string name,
                                                  Guid publicId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.PublicId = publicId;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public Guid PublicId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>85b3355c241a7018bb81f5e2e705e710</Hash>
</Codenesium>*/