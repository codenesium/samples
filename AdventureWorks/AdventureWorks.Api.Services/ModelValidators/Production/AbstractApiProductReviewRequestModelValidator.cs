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

                IProductReviewRepository productReviewRepository;

                public AbstractApiProductReviewRequestModelValidator(IProductReviewRepository productReviewRepository)
                {
                        this.productReviewRepository = productReviewRepository;
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
    <Hash>51f72a7956920ec1eaa1705781142fa5</Hash>
</Codenesium>*/