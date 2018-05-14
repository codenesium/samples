using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractApiLessonStatusModelValidator: AbstractValidator<ApiLessonStatusModel>
	{
		public new ValidationResult Validate(ApiLessonStatusModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLessonStatusModel model)
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
			return this.StudioRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>bdc31a5b2bc14a7c4decd728f76fe967</Hash>
</Codenesium>*/