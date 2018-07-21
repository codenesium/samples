using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
        public interface IApiSchemaBPersonRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSchemaBPersonRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaBPersonRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>aba2bd9e7282cd554ea2d629e731670b</Hash>
</Codenesium>*/