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
	public abstract class AbstractApiRateRequestModelValidator: AbstractValidator<ApiRateRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiRateRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiRateRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public ITeacherRepository TeacherRepository { get; set; }
		public ITeacherSkillRepository TeacherSkillRepository { get; set; }
		public virtual void AmountPerMinuteRules()
		{
			this.RuleFor(x => x.AmountPerMinute).NotNull();
		}

		public virtual void TeacherIdRules()
		{
			this.RuleFor(x => x.TeacherId).NotNull();
			this.RuleFor(x => x.TeacherId).MustAsync(this.BeValidTeacher).When(x => x ?.TeacherId != null).WithMessage("Invalid reference");
		}

		public virtual void TeacherSkillIdRules()
		{
			this.RuleFor(x => x.TeacherSkillId).NotNull();
			this.RuleFor(x => x.TeacherSkillId).MustAsync(this.BeValidTeacherSkill).When(x => x ?.TeacherSkillId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidTeacher(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TeacherRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidTeacherSkill(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TeacherSkillRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>65435ca6bfc460f3f00a299c66192c43</Hash>
</Codenesium>*/