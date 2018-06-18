using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductReviewRequestModelValidator: AbstractApiProductReviewRequestModelValidator, IApiProductReviewRequestModelValidator
        {
                public ApiProductReviewRequestModelValidator(IProductReviewRepository productReviewRepository)
                        : base(productReviewRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductReviewRequestModel model)
                {
                        this.CommentsRules();
                        this.EmailAddressRules();
                        this.ModifiedDateRules();
                        this.ProductIDRules();
                        this.RatingRules();
                        this.ReviewDateRules();
                        this.ReviewerNameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductReviewRequestModel model)
                {
                        this.CommentsRules();
                        this.EmailAddressRules();
                        this.ModifiedDateRules();
                        this.ProductIDRules();
                        this.RatingRules();
                        this.ReviewDateRules();
                        this.ReviewerNameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>9a3f9ba273b16c331e733811d98d6c2d</Hash>
</Codenesium>*/