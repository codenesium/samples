using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductReviewRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductReviewRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductReviewRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c742a0915393a4729b0f68f970bc4dc8</Hash>
</Codenesium>*/