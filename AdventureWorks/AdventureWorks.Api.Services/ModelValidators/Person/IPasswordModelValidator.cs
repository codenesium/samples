using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiPasswordRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPasswordRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPasswordRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>72bba00f2d99ca8cdf6f1e4ced2d868b</Hash>
</Codenesium>*/