using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiLessonStatusRequestModelValidator: AbstractApiLessonStatusRequestModelValidator, IApiLessonStatusRequestModelValidator
        {
                public ApiLessonStatusRequestModelValidator(ILessonStatusRepository lessonStatusRepository)
                        : base(lessonStatusRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiLessonStatusRequestModel model)
                {
                        this.NameRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonStatusRequestModel model)
                {
                        this.NameRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>75b1a24437ea041781e3d71e507e9589</Hash>
</Codenesium>*/