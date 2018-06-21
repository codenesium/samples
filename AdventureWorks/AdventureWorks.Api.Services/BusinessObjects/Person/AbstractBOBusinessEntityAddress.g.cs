using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOBusinessEntityAddress : AbstractBusinessObject
        {
                public AbstractBOBusinessEntityAddress()
                        : base()
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
    <Hash>871774bf9e35e649e7a57c92a86188ed</Hash>
</Codenesium>*/