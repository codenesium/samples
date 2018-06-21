using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>72ae241a17eeef7a089600774d48744f</Hash>
</Codenesium>*/