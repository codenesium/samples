using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOEmployeePayHistory: AbstractBusinessObject
        {
                public BOEmployeePayHistory() : base()
                {
                }

                public void SetProperties(int businessEntityID,
                                          DateTime modifiedDate,
                                          int payFrequency,
                                          decimal rate,
                                          DateTime rateChangeDate)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.PayFrequency = payFrequency;
                        this.Rate = rate;
                        this.RateChangeDate = rateChangeDate;
                }

                public int BusinessEntityID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int PayFrequency { get; private set; }

                public decimal Rate { get; private set; }

                public DateTime RateChangeDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2e99d6face23859d873597da2df6cb66</Hash>
</Codenesium>*/