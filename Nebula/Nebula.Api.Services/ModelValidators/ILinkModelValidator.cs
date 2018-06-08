using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.Services
{
        public interface IApiLinkRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLinkRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>02916fdebfd17d5029b9887b63d832b0</Hash>
</Codenesium>*/