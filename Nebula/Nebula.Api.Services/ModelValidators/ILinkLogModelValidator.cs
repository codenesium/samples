using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.Services
{
        public interface IApiLinkLogRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLinkLogRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkLogRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c0820dc5e77d95a7360a1a3f265d6da4</Hash>
</Codenesium>*/