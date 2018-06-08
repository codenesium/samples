using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

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
    <Hash>93512ed8e9827f2ef73cfae046d0431e</Hash>
</Codenesium>*/