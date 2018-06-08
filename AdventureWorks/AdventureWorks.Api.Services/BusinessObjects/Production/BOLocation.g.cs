using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOLocation: AbstractBusinessObject
        {
                public BOLocation() : base()
                {
                }

                public void SetProperties(short locationID,
                                          decimal availability,
                                          decimal costRate,
                                          DateTime modifiedDate,
                                          string name)
                {
                        this.Availability = availability;
                        this.CostRate = costRate;
                        this.LocationID = locationID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public decimal Availability { get; private set; }

                public decimal CostRate { get; private set; }

                public short LocationID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b6e49afedfc77e2de8f7503e08c69361</Hash>
</Codenesium>*/