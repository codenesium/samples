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
        public abstract class AbstractApiSpaceRequestModelValidator : AbstractValidator<ApiSpaceRequestModel>
        {
                private int existingRecordId;

                private ISpaceRepository spaceRepository;

                public AbstractApiSpaceRequestModelValidator(ISpaceRepository spaceRepository)
                {
                        this.spaceRepository = spaceRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSpaceRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DescriptionRules()
                {
                        this.RuleFor(x => x.Description).Length(0, 128);
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
                        var record = await this.spaceRepository.GetStudio(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>bf78d6e68dd4dd2f447c0b93d313531d</Hash>
</Codenesium>*/