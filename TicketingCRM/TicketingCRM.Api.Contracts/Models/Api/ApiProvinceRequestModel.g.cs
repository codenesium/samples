using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiProvinceRequestModel: AbstractApiRequestModel
        {
                public ApiProvinceRequestModel() : base()
                {
                }

                public void SetProperties(
                        int countryId,
                        string name)
                {
                        this.CountryId = countryId;
                        this.Name = name;
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
    <Hash>509b7b649461091969d5fe2e72b95c39</Hash>
</Codenesium>*/