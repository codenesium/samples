using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiChainStatusRequestModelValidator: AbstractApiChainStatusRequestModelValidator, IApiChainStatusRequestModelValidator
        {
                public ApiChainStatusRequestModelValidator(IChainStatusRepository chainStatusRepository)
                        : base(chainStatusRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiChainStatusRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatusRequestModel model)
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
    <Hash>5c4d67181ef52315571b542020a9f16f</Hash>
</Codenesium>*/