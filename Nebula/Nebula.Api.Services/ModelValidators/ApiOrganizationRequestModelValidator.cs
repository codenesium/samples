using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiOrganizationRequestModelValidator: AbstractApiOrganizationRequestModelValidator, IApiOrganizationRequestModelValidator
        {
                public ApiOrganizationRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiOrganizationRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOrganizationRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>8d48f01cb355940d545f21cd7467e41d</Hash>
</Codenesium>*/