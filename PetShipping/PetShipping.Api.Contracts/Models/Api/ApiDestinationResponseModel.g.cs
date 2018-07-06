using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiDestinationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int countryId,
                        string name,
                        int order)
                {
                        this.Id = id;
                        this.CountryId = countryId;
                        this.Name = name;
                        this.Order = order;

                        this.CountryIdEntity = nameof(ApiResponse.Countries);
                }

                public int CountryId { get; private set; }

                public string CountryIdEntity { get; set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int Order { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5e5a54d39a86f5f5422504406d382792</Hash>
</Codenesium>*/