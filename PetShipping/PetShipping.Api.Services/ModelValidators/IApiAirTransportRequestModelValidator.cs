using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>c466b10f60d81e70c8d2cc8cf42d1b9e</Hash>
</Codenesium>*/