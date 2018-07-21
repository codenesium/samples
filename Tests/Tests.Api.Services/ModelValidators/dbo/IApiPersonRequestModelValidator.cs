using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
        public interface IApiPersonRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPersonRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>747d3c6bb8c6cbfdee928e7f67ebb7a3</Hash>
</Codenesium>*/