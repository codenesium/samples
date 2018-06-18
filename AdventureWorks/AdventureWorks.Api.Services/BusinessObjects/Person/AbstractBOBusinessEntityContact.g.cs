using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOBusinessEntityContact: AbstractBusinessObject
        {
                public AbstractBOBusinessEntityContact() : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
                                                  int contactTypeID,
                                                  DateTime modifiedDate,
                                                  int personID,
                                                  Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ContactTypeID = contactTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.PersonID = personID;
                        this.Rowguid = rowguid;
                }

                public int BusinessEntityID { get; private set; }

                public int ContactTypeID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int PersonID { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1eb80b060071e94e6533577872d8e70d</Hash>
</Codenesium>*/