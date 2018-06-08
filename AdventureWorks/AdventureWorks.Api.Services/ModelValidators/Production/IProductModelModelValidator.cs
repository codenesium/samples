using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductModelRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductModelRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>7a8d29d02586d6f35f25d6c0a8199b4a</Hash>
</Codenesium>*/