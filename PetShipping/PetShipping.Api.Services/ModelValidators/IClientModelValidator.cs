using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiClientRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiClientRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>b1afb42ff5c4c65abf044fbc925676b2</Hash>
</Codenesium>*/