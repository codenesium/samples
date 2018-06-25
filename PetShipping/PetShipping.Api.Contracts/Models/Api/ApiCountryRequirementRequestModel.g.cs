using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiCountryRequirementRequestModel : AbstractApiRequestModel
        {
                public ApiCountryRequirementRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int countryId,
                        string details)
                {
                        this.CountryId = countryId;
                        this.Details = details;
                }

                private int countryId;

                [Required]
                public int CountryId
                {
                        get
                        {
                                return this.countryId;
                        }

                        set
                        {
                                this.countryId = value;
                        }
                }

                private string details;

                [Required]
                public string Details
                {
                        get
                        {
                                return this.details;
                        }

                        set
                        {
                                this.details = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>4ba24902b5e3e19a7671e6e88dc733e4</Hash>
</Codenesium>*/