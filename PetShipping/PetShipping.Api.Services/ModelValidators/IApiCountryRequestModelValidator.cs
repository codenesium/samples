using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiCountryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCountryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>b49937c70f39968a2663896e5e59dcc4</Hash>
</Codenesium>*/