using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>8a4619703d301a75efb8019eee5727b1</Hash>
</Codenesium>*/