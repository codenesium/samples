using Codenesium.DataConversionExtensions.AspNetCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractApiSpaceXSpaceFeatureRequestModelValidator : AbstractValidator<ApiSpaceXSpaceFeatureRequestModel>
        {
                private int existingRecordId;

                private ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository;

                public AbstractApiSpaceXSpaceFeatureRequestModelValidator(ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository)
                {
                        this.spaceXSpaceFeatureRepository = spaceXSpaceFeatureRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSpaceXSpaceFeatureRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void SpaceFeatureIdRules()
                {
                        this.RuleFor(x => x.SpaceFeatureId).MustAsync(this.BeValidSpaceFeature).When(x => x?.SpaceFeatureId != null).WithMessage("Invalid reference");
                }

                public virtual void SpaceIdRules()
                {
                        this.RuleFor(x => x.SpaceId).MustAsync(this.BeValidSpace).When(x => x?.SpaceId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidSpaceFeature(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.spaceXSpaceFeatureRepository.GetSpaceFeature(id);

                        return record != null;
                }

                private async Task<bool> BeValidSpace(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.spaceXSpaceFeatureRepository.GetSpace(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>44455f7e3dd21726cc4414764721d515</Hash>
</Codenesium>*/