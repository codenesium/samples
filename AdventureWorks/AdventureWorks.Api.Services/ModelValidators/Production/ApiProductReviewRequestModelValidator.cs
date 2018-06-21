using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductReviewRequestModelValidator : AbstractApiProductReviewRequestModelValidator, IApiProductReviewRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>10a7edc9abf696266ed2c22788143437</Hash>
</Codenesium>*/