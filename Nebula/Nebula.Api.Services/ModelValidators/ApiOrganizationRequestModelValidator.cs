using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public class ApiOrganizationRequestModelValidator : AbstractApiOrganizationRequestModelValidator, IApiOrganizationRequestModelValidator
        {
                public ApiOrganizationRequestModelValidator(IOrganizationRepository organizationRepository)
                        : base(organizationRepository)
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>19add123ae228bf29fb4d4e0f738cdce</Hash>
</Codenesium>*/