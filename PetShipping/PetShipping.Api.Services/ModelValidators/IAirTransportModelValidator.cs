using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiAirTransportRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiAirTransportRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirTransportRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>de8172d6d0ee5a5ab7ceb9ad1cf69abb</Hash>
</Codenesium>*/