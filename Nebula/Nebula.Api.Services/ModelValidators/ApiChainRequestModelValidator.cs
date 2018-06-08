using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiChainRequestModelValidator: AbstractApiChainRequestModelValidator, IApiChainRequestModelValidator
        {
                public ApiChainRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiChainRequestModel model)
                {
                        this.ChainStatusIdRules();
                        this.ExternalIdRules();
                        this.NameRules();
                        this.TeamIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainRequestModel model)
                {
                        this.ChainStatusIdRules();
                        this.ExternalIdRules();
                        this.NameRules();
                        this.TeamIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>3d26c207dd1cb442abd3752dccd1a32a</Hash>
</Codenesium>*/