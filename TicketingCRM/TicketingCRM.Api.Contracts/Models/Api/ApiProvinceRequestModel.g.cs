using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiProvinceRequestModel : AbstractApiRequestModel
        {
                public ApiProvinceRequestModel()
                        : base()
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
    <Hash>e36d20a57a1d31a7e97cfda113faf06d</Hash>
</Codenesium>*/