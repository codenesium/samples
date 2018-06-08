using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.Services
{
        public interface IApiLessonRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLessonRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>87b7044dae1e37943370d2b0346a8f20</Hash>
</Codenesium>*/