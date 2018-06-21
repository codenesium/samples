using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiFeedRequestModelValidator : AbstractValidator<ApiFeedRequestModel>
        {
                private string existingRecordId;

                private IFeedRepository feedRepository;

                public AbstractApiFeedRequestModelValidator(IFeedRepository feedRepository)
                {
                        this.feedRepository = feedRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiFeedRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void FeedTypeRules()
                {
                        this.RuleFor(x => x.FeedType).NotNull();
                        this.RuleFor(x => x.FeedType).Length(0, 50);
                }

                public virtual void FeedUriRules()
                {
                        this.RuleFor(x => x.FeedUri).NotNull();
                        this.RuleFor(x => x.FeedUri).Length(0, 512);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiFeedRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                private async Task<bool> BeUniqueGetName(ApiFeedRequestModel model,  CancellationToken cancellationToken)
                {
                        Feed record = await this.feedRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>97ec4988173d2878aeddd6da94102bfe</Hash>
</Codenesium>*/