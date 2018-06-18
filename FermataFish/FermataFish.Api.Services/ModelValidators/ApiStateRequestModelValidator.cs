using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiStateRequestModelValidator: AbstractApiStateRequestModelValidator, IApiStateRequestModelValidator
        {
                public ApiStateRequestModelValidator(IStateRepository stateRepository)
                        : base(stateRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiStateRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateRequestModel model)
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
    <Hash>fc65b25846ac101acd9aa0edd185d3cb</Hash>
</Codenesium>*/