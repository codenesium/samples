using Codenesium.DataConversionExtensions.AspNetCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractApiLessonStatusRequestModelValidator : AbstractValidator<ApiLessonStatusRequestModel>
        {
                private int existingRecordId;

                private ILessonStatusRepository lessonStatusRepository;

                public AbstractApiLessonStatusRequestModelValidator(ILessonStatusRepository lessonStatusRepository)
                {
                        this.lessonStatusRepository = lessonStatusRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiLessonStatusRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void StudioIdRules()
                {
                        this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x?.StudioId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.lessonStatusRepository.GetStudio(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>1fb7f4c60437b4c63603204265384c7e</Hash>
</Codenesium>*/