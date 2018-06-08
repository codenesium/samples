using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiTeamRequestModelValidator: AbstractApiTeamRequestModelValidator, IApiTeamRequestModelValidator
        {
                public ApiTeamRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiTeamRequestModel model)
                {
                        this.NameRules();
                        this.OrganizationIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeamRequestModel model)
                {
                        this.NameRules();
                        this.OrganizationIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>b6a693c865506869da9a40e3c1f3a763</Hash>
</Codenesium>*/