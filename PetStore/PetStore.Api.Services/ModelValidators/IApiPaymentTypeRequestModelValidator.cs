using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public interface IApiPaymentTypeRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPaymentTypeRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPaymentTypeRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>14b34fd8dfd27112977bf3c6402451b4</Hash>
</Codenesium>*/