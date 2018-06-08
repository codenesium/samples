using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

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
    <Hash>66a05aa7494a552962c0145f98999898</Hash>
</Codenesium>*/