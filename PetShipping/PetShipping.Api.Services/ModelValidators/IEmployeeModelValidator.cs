using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiEmployeeRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiEmployeeRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>94e191cc2f74aed7c1279c7021250c31</Hash>
</Codenesium>*/