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
	public abstract class AbstractApiLessonStatusRequestModelValidator: AbstractValidator<ApiLessonStatusRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiLessonStatusRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLessonStatusRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IStudioRepository StudioRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void StudioIdRules()
		{
			this.RuleFor(x => x.StudioId).NotNull();
			this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x ?.StudioId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
		{
			var record = await this.StudioRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>61f4b61b0522e150e37c9145504966e4</Hash>
</Codenesium>*/