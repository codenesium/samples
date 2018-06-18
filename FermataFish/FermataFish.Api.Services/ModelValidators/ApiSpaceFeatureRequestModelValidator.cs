using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiSpaceFeatureRequestModelValidator: AbstractApiSpaceFeatureRequestModelValidator, IApiSpaceFeatureRequestModelValidator
        {
                public ApiSpaceFeatureRequestModelValidator(ISpaceFeatureRepository spaceFeatureRepository)
                        : base(spaceFeatureRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureRequestModel model)
                {
                        this.NameRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureRequestModel model)
                {
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
    <Hash>58800bf9b157c004dc9cbeffd97a7f29</Hash>
</Codenesium>*/