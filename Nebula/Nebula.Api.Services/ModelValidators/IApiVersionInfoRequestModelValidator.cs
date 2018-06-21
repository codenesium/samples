using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface IApiVersionInfoRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(long id);
        }
}

/*<Codenesium>
    <Hash>b855339e7637112c4b54eded28b07d58</Hash>
</Codenesium>*/