using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
        public interface IApiTestAllFieldTypeRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTestAllFieldTypeRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTestAllFieldTypeRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>4c87b60b175fd2ae78ff7201e7510eec</Hash>
</Codenesium>*/