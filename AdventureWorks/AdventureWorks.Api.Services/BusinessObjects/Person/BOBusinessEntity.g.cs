using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOBusinessEntity: AbstractBusinessObject
        {
                public BOBusinessEntity() : base()
                {
                }

                public void SetProperties(int businessEntityID,
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
    <Hash>43e91c614dda02702e3e03dd325a8a24</Hash>
</Codenesium>*/