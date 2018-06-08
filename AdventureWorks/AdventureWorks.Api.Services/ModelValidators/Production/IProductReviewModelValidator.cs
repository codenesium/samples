using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>838e540e4c233339eca046f83bcabd8a</Hash>
</Codenesium>*/