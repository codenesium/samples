using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiProductReviewRequestModelValidator: AbstractValidator<ApiProductReviewRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiProductReviewRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductReviewRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CommentsRules()
                {
                        this.RuleFor(x => x.Comments).Length(0, 3850);
                }

                public virtual void EmailAddressRules()
                {
                        this.RuleFor(x => x.EmailAddress).NotNull();
                        this.RuleFor(x => x.EmailAddress).Length(0, 50);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void ProductIDRules()
                {
                }

                public virtual void RatingRules()
                {
                }

                public virtual void ReviewDateRules()
                {
                }

                public virtual void ReviewerNameRules()
                {
                        this.RuleFor(x => x.ReviewerName).NotNull();
                        this.RuleFor(x => x.ReviewerName).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>82a80c157f0042a209895705cd67c2f0</Hash>
</Codenesium>*/