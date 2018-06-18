using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiClaspRequestModelValidator: AbstractApiClaspRequestModelValidator, IApiClaspRequestModelValidator
        {
                public ApiClaspRequestModelValidator(IClaspRepository claspRepository)
                        : base(claspRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiClaspRequestModel model)
                {
                        this.NextChainIdRules();
                        this.PreviousChainIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiClaspRequestModel model)
                {
                        this.NextChainIdRules();
                        this.PreviousChainIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>26c57cf6f509e31ed3955971b8fda6a4</Hash>
</Codenesium>*/