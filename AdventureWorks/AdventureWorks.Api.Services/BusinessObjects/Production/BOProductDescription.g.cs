using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProductDescription: AbstractBusinessObject
        {
                public BOProductDescription() : base()
                {
                }

                public void SetProperties(int productDescriptionID,
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
    <Hash>f37aec28b8935bc85255ac21857d8370</Hash>
</Codenesium>*/