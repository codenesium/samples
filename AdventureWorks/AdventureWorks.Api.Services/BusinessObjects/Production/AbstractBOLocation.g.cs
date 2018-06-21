using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOLocation : AbstractBusinessObject
        {
                public AbstractBOLocation()
                        : base()
                {
                }

                public virtual void SetProperties(short locationID,
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
    <Hash>ebb290e23f6b078686813765c963be20</Hash>
</Codenesium>*/