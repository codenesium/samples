using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOBusinessEntity: AbstractBusinessObject
        {
                public AbstractBOBusinessEntity() : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
                                                  DateTime modifiedDate,
                                                  Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                public int BusinessEntityID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a63a82b82b6b0e90fa8705c31fbcccd2</Hash>
</Codenesium>*/