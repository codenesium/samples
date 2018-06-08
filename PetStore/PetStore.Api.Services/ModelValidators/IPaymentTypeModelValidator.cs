using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;

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
    <Hash>fb658bad206b1c1730643446576cc511</Hash>
</Codenesium>*/