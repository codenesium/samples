using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractApiSpaceFeatureRequestModelValidator : AbstractValidator<ApiSpaceFeatureRequestModel>
        {
                private int existingRecordId;

                private ISpaceFeatureRepository spaceFeatureRepository;

                public AbstractApiSpaceFeatureRequestModelValidator(ISpaceFeatureRepository spaceFeatureRepository)
                {
                        this.spaceFeatureRepository = spaceFeatureRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSpaceFeatureRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void StudioIdRules()
                {
                        this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x?.StudioId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.spaceFeatureRepository.GetStudio(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>a47990544e11e22dc51d85b0e8ec42f3</Hash>
</Codenesium>*/