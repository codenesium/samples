using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOBusinessEntityAddress: AbstractBusinessObject
        {
                public BOBusinessEntityAddress() : base()
                {
                }

                public void SetProperties(int businessEntityID,
                                          int addressID,
                                          int addressTypeID,
                                          DateTime modifiedDate,
                                          Guid rowguid)
                {
                        this.AddressID = addressID;
                        this.AddressTypeID = addressTypeID;
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                public int AddressID { get; private set; }

                public int AddressTypeID { get; private set; }

                public int BusinessEntityID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>68c5a23c10be61b38aab6c976a969d51</Hash>
</Codenesium>*/