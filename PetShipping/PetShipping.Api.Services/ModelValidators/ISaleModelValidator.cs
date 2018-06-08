using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

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
    <Hash>ff61e78169cd9d8ebcdde7a5297794c9</Hash>
</Codenesium>*/