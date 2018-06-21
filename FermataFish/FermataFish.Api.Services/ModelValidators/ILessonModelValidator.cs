using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>7fa208339a89238a787896fa299fd595</Hash>
</Codenesium>*/