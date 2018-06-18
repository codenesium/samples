using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiSpaceXSpaceFeatureRequestModelValidator: AbstractApiSpaceXSpaceFeatureRequestModelValidator, IApiSpaceXSpaceFeatureRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>f99028ade99a4e567826d4f83bb782b0</Hash>
</Codenesium>*/