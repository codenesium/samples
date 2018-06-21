using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public class ApiChainRequestModelValidator : AbstractApiChainRequestModelValidator, IApiChainRequestModelValidator
        {
                public ApiChainRequestModelValidator(IChainRepository chainRepository)
                        : base(chainRepository)
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>9121f0894b7615d880f14f2863e0b14f</Hash>
</Codenesium>*/