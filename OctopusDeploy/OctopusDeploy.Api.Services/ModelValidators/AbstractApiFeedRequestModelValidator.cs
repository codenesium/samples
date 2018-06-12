using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiFeedRequestModelValidator: AbstractValidator<ApiFeedRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiFeedRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiFeedRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IFeedRepository FeedRepository { get; set; }
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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiFeedRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                private async Task<bool> BeUniqueGetName(ApiFeedRequestModel model,  CancellationToken cancellationToken)
                {
                        Feed record = await this.FeedRepository.GetName(model.Name);

                        if (record == null || record.Id == this.existingRecordId)
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
    <Hash>d8a9c1cee029f58bb0218f5241e87bed</Hash>
</Codenesium>*/