using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOStore: AbstractBusinessObject
        {
                public BOStore() : base()
                {
                }

                public void SetProperties(int businessEntityID,
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
    <Hash>dd157398626e658fe6f496f278f8d4c7</Hash>
</Codenesium>*/