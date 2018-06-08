using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services

{
        public abstract class AbstractApiSpaceXSpaceFeatureRequestModelValidator: AbstractValidator<ApiSpaceXSpaceFeatureRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiSpaceXSpaceFeatureRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSpaceXSpaceFeatureRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ISpaceFeatureRepository SpaceFeatureRepository { get; set; }

                public ISpaceRepository SpaceRepository { get; set; }

                public virtual void SpaceFeatureIdRules()
                {
                        this.RuleFor(x => x.SpaceFeatureId).NotNull();
                        this.RuleFor(x => x.SpaceFeatureId).MustAsync(this.BeValidSpaceFeature).When(x => x ?.SpaceFeatureId != null).WithMessage("Invalid reference");
                }

                public virtual void SpaceIdRules()
                {
                        this.RuleFor(x => x.SpaceId).NotNull();
                        this.RuleFor(x => x.SpaceId).MustAsync(this.BeValidSpace).When(x => x ?.SpaceId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidSpaceFeature(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.SpaceFeatureRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidSpace(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.SpaceRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>6c632dfbba561b9b7aef78bbbf21e73e</Hash>
</Codenesium>*/