using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiCustomerRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCustomerRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>f2fb819f39d09397e2ac3e0b867cb3e9</Hash>
</Codenesium>*/