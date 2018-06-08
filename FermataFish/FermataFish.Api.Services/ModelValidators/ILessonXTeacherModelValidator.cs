using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.Services
{
        public interface IApiLessonXTeacherRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLessonXTeacherRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXTeacherRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>ff3c2aa01b59f8c5b1386d076649ec43</Hash>
</Codenesium>*/