using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public class ApiSpaceFeatureRequestModelValidator : AbstractApiSpaceFeatureRequestModelValidator, IApiSpaceFeatureRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>238765442c52dec49347f8163f7e00a0</Hash>
</Codenesium>*/