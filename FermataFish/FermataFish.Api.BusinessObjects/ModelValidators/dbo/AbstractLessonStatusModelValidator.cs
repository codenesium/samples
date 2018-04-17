using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractLessonStatusModelValidator: AbstractValidator<LessonStatusModel>
	{
		public new ValidationResult Validate(LessonStatusModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(LessonStatusModel model)
		{
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
			this.RuleFor(x => x.StudioId).Must(this.BeValidStudio).When(x => x ?.StudioId != null).WithMessage("Invalid reference");
		}

		private bool BeValidStudio(int id)
		{
			return this.StudioRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>2802ed8b15c8c2a409eab2fbebdff7cb</Hash>
</Codenesium>*/