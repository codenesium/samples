using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public class ApiSpaceXSpaceFeatureRequestModelValidator : AbstractApiSpaceXSpaceFeatureRequestModelValidator, IApiSpaceXSpaceFeatureRequestModelValidator
        {
                public ApiSpaceXSpaceFeatureRequestModelValidator(ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository)
                        : base(spaceXSpaceFeatureRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceXSpaceFeatureRequestModel model)
                {
                        this.SpaceFeatureIdRules();
                        this.SpaceIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceXSpaceFeatureRequestModel model)
                {
                        this.SpaceFeatureIdRules();
                        this.SpaceIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>6920a5550041e7700479c1a7f827b512</Hash>
</Codenesium>*/