using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services

{
        public abstract class AbstractApiLessonXTeacherRequestModelValidator: AbstractValidator<ApiLessonXTeacherRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiLessonXTeacherRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiLessonXTeacherRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ILessonRepository LessonRepository { get; set; }

                public IStudentRepository StudentRepository { get; set; }

                public virtual void LessonIdRules()
                {
                        this.RuleFor(x => x.LessonId).NotNull();
                        this.RuleFor(x => x.LessonId).MustAsync(this.BeValidLesson).When(x => x ?.LessonId != null).WithMessage("Invalid reference");
                }

                public virtual void StudentIdRules()
                {
                        this.RuleFor(x => x.StudentId).NotNull();
                        this.RuleFor(x => x.StudentId).MustAsync(this.BeValidStudent).When(x => x ?.StudentId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidLesson(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.LessonRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidStudent(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.StudentRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>31c5d841b5b6a22982ac4d74e4393e26</Hash>
</Codenesium>*/