using Codenesium.DataConversionExtensions;
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
    <Hash>b14c56a617687523e92904805506c7ea</Hash>
</Codenesium>*/