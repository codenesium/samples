using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiDestinationRequestModel : AbstractApiRequestModel
        {
                public ApiDestinationRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        int countryId,
                        string name,
                        int order)
                {
                        this.CountryId = countryId;
                        this.Name = name;
                        this.Order = order;
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

                private int order;

                [Required]
                public int Order
                {
                        get
                        {
                                return this.order;
                        }

                        set
                        {
                                this.order = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>e83589f749a898d119d56ee2e6a59c6b</Hash>
</Codenesium>*/