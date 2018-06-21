using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiSaleRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c49735cc6a4c9f1fb3cce27e40b50ddc</Hash>
</Codenesium>*/