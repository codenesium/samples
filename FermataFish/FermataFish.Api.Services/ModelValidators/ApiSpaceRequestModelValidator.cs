using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiSpaceRequestModelValidator: AbstractApiSpaceRequestModelValidator, IApiSpaceRequestModelValidator
        {
                public ApiSpaceRequestModelValidator(ISpaceRepository spaceRepository)
                        : base(spaceRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceRequestModel model)
                {
                        this.DescriptionRules();
                        this.NameRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceRequestModel model)
                {
                        this.DescriptionRules();
                        this.NameRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>76f0e804106a1b4e639e82a3f183aff5</Hash>
</Codenesium>*/