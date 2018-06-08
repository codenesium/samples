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
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void ProductIDRules()
                {
                        this.RuleFor(x => x.ProductID).NotNull();
                }

                public virtual void RatingRules()
                {
                        this.RuleFor(x => x.Rating).NotNull();
                }

                public virtual void ReviewDateRules()
                {
                        this.RuleFor(x => x.ReviewDate).NotNull();
                }

                public virtual void ReviewerNameRules()
                {
                        this.RuleFor(x => x.ReviewerName).NotNull();
                        this.RuleFor(x => x.ReviewerName).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>4f3f830f7a4dfef49f7eedbdc3307d85</Hash>
</Codenesium>*/