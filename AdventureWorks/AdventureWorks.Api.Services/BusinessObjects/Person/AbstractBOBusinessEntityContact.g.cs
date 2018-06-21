using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOBusinessEntityContact : AbstractBusinessObject
        {
                public AbstractBOBusinessEntityContact()
                        : base()
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
    <Hash>aa66263029338eb2212198c76b274719</Hash>
</Codenesium>*/