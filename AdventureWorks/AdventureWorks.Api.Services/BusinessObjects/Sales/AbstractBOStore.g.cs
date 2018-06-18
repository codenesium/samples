using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOStore: AbstractBusinessObject
        {
                public AbstractBOStore() : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
                                                  string demographics,
                                                  DateTime modifiedDate,
                                                  string name,
                                                  Guid rowguid,
                                                  Nullable<int> salesPersonID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.Demographics = demographics;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.SalesPersonID = salesPersonID;
                }

                public int BusinessEntityID { get; private set; }

                public string Demographics { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public Guid Rowguid { get; private set; }

                public Nullable<int> SalesPersonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1b5a66cb138d043a61b6379215b279cb</Hash>
</Codenesium>*/