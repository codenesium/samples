using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>b3ef0a66f0bfccc6084b9581d4ee0542</Hash>
</Codenesium>*/