using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiTeamRequestModelValidator: AbstractApiTeamRequestModelValidator, IApiTeamRequestModelValidator
        {
                public ApiTeamRequestModelValidator(ITeamRepository teamRepository)
                        : base(teamRepository)
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
    <Hash>04cd979a3e67b9df6dd7518e72037ef9</Hash>
</Codenesium>*/