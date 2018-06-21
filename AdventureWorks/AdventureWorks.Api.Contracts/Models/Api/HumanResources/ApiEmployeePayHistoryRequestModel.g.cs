using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiEmployeePayHistoryRequestModel : AbstractApiRequestModel
        {
                public ApiEmployeePayHistoryRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        int payFrequency,
                        decimal rate,
                        DateTime rateChangeDate)
                {
                        this.ModifiedDate = modifiedDate;
                        this.PayFrequency = payFrequency;
                        this.Rate = rate;
                        this.RateChangeDate = rateChangeDate;
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private int payFrequency;

                [Required]
                public int PayFrequency
                {
                        get
                        {
                                return this.payFrequency;
                        }

                        set
                        {
                                this.payFrequency = value;
                        }
                }

                private decimal rate;

                [Required]
                public decimal Rate
                {
                        get
                        {
                                return this.rate;
                        }

                        set
                        {
                                this.rate = value;
                        }
                }

                private DateTime rateChangeDate;

                [Required]
                public DateTime RateChangeDate
                {
                        get
                        {
                                return this.rateChangeDate;
                        }

                        set
                        {
                                this.rateChangeDate = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>8923b7a2493a8aea6683b37928216245</Hash>
</Codenesium>*/