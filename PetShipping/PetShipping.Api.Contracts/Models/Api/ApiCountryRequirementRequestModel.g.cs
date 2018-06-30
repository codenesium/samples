using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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
    <Hash>7e969f4a81b074f27795530f9a4a814e</Hash>
</Codenesium>*/