using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.Services
{
        public interface IApiOrganizationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiOrganizationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiOrganizationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>7ddc91536e57c00d6af19d132a4228a5</Hash>
</Codenesium>*/