using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IApiLessonStatusRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLessonStatusRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonStatusRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>ab06cbe0596ba84c4e2bc05aa132101f</Hash>
</Codenesium>*/