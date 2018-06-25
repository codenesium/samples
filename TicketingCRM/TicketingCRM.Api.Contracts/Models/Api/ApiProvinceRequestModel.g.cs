using Codenesium.DataConversionExtensions;
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

                public virtual void SetProperties(
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
    <Hash>6ce565a8b177dc0b02a6705e72364402</Hash>
</Codenesium>*/