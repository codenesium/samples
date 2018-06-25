using Codenesium.DataConversionExtensions;
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

                public virtual void SetProperties(
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
    <Hash>dbac62c18a44efe3e3320858c27d7a8a</Hash>
</Codenesium>*/