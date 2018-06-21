using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>6e5693b093e018d60c58a37bc2638ea2</Hash>
</Codenesium>*/