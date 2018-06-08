using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiClaspRequestModelValidator: AbstractApiClaspRequestModelValidator, IApiClaspRequestModelValidator
        {
                public ApiClaspRequestModelValidator()
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
    <Hash>dc27679505756a98186543bc99c4d15d</Hash>
</Codenesium>*/