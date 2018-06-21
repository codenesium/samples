using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>f596be8459217bd9f56ecff4db558c2a</Hash>
</Codenesium>*/