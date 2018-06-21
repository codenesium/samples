using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
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
    <Hash>1121269d962c3de02f136b2328db9987</Hash>
</Codenesium>*/