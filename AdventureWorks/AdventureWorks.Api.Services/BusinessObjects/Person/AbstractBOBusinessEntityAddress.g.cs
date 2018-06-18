using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOBusinessEntityAddress: AbstractBusinessObject
        {
                public AbstractBOBusinessEntityAddress() : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
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
    <Hash>74c638c2eea0ff36b6f7a7dddc7e07bd</Hash>
</Codenesium>*/