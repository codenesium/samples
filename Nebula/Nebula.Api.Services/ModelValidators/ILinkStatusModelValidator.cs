using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.Services
{
        public interface IApiLinkStatusRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>f17a3163da34c0a51256e12d19132595</Hash>
</Codenesium>*/