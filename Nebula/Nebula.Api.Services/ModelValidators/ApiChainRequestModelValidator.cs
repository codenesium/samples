using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiChainRequestModelValidator: AbstractApiChainRequestModelValidator, IApiChainRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>64adacb991ed92fbebab396ba0f24422</Hash>
</Codenesium>*/