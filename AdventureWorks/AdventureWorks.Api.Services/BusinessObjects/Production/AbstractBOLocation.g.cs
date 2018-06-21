using Codenesium.DataConversionExtensions;
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
    <Hash>51c17bbc1d781ef5508ed87a00240e32</Hash>
</Codenesium>*/