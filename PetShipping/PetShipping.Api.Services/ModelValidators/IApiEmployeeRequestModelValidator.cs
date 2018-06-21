using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>965cb85869777f7e3eff477394064124</Hash>
</Codenesium>*/