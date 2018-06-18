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
        public abstract class AbstractApiStudioRequestModelValidator: AbstractValidator<ApiStudioRequestModel>
        {
                private int existingRecordId;

                IStudioRepository studioRepository;

                public AbstractApiStudioRequestModelValidator(IStudioRepository studioRepository)
                {
                        this.studioRepository = studioRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiStudioRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void Address1Rules()
                {
                        this.RuleFor(x => x.Address1).NotNull();
                        this.RuleFor(x => x.Address1).Length(0, 128);
                }

                public virtual void Address2Rules()
                {
                        this.RuleFor(x => x.Address2).NotNull();
                        this.RuleFor(x => x.Address2).Length(0, 128);
                }

                public virtual void CityRules()
                {
                        this.RuleFor(x => x.City).NotNull();
                        this.RuleFor(x => x.City).Length(0, 128);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void StateIdRules()
                {
                        this.RuleFor(x => x.StateId).MustAsync(this.BeValidState).When(x => x ?.StateId != null).WithMessage("Invalid reference");
                }

                public virtual void WebsiteRules()
                {
                        this.RuleFor(x => x.Website).NotNull();
                        this.RuleFor(x => x.Website).Length(0, 128);
                }

                public virtual void ZipRules()
                {
                        this.RuleFor(x => x.Zip).NotNull();
                        this.RuleFor(x => x.Zip).Length(0, 128);
                }

                private async Task<bool> BeValidState(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.studioRepository.GetState(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>a06495f301226c518b2f0dcd39bec792</Hash>
</Codenesium>*/