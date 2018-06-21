using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOProductDescription : AbstractBusinessObject
        {
                public AbstractBOProductDescription()
                        : base()
                {
                }

                public virtual void SetProperties(int productDescriptionID,
                                                  string description,
                                                  DateTime modifiedDate,
                                                  Guid rowguid)
                {
                        this.Description = description;
                        this.ModifiedDate = modifiedDate;
                        this.ProductDescriptionID = productDescriptionID;
                        this.Rowguid = rowguid;
                }

                public string Description { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductDescriptionID { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7129bab29b6b7ae3e4372a756c690a16</Hash>
</Codenesium>*/