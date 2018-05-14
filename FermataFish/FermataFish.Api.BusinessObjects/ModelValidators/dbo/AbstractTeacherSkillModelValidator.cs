using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractApiTeacherSkillModelValidator: AbstractValidator<ApiTeacherSkillModel>
	{
		public new ValidationResult Validate(ApiTeacherSkillModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeacherSkillModel model)
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
    <Hash>23d5220eddf62401b3e4d30e7dd6d4c2</Hash>
</Codenesium>*/