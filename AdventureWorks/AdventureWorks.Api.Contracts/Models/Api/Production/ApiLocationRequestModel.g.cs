using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiLocationRequestModel : AbstractApiRequestModel
        {
                public ApiLocationRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        decimal availability,
                        decimal costRate,
                        DateTime modifiedDate,
                        string name)
                {
                        this.Availability = availability;
                        this.CostRate = costRate;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                private decimal availability;

                [Required]
                public decimal Availability
                {
                        get
                        {
                                return this.availability;
                        }

                        set
                        {
                                this.availability = value;
                        }
                }

                private decimal costRate;

                [Required]
                public decimal CostRate
                {
                        get
                        {
                                return this.costRate;
                        }

                        set
                        {
                                this.costRate = value;
                        }
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

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>212b7f34cc469fd7cf71066c38b9d6a2</Hash>
</Codenesium>*/