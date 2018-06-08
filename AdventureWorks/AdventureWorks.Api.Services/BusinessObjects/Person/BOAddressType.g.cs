using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOAddressType: AbstractBusinessObject
        {
                public BOAddressType() : base()
                {
                }

                public void SetProperties(int addressTypeID,
                                          DateTime modifiedDate,
                                          string name,
                                          Guid rowguid)
                {
                        this.AddressTypeID = addressTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                }

                public int AddressTypeID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>03bdcda3ef6d6d73f050947514a95415</Hash>
</Codenesium>*/