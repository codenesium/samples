using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>ff0e8cc11c20f9745e8c52df1f5917d6</Hash>
</Codenesium>*/