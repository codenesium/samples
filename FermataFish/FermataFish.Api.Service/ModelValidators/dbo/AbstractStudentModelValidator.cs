using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Service

{
	public abstract class AbstractStudentModelValidator: AbstractValidator<StudentModel>
	{
		public new ValidationResult Validate(StudentModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(StudentModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IFamilyRepository FamilyRepository { get; set; }
		public IStudioRepository StudioRepository { get; set; }
		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).NotNull();
			this.RuleFor(x => x.Email).Length(0, 128);
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull();
			this.RuleFor(x => x.FirstName).Length(0, 128);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull();
			this.RuleFor(x => x.LastName).Length(0, 128);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).NotNull();
			this.RuleFor(x => x.Phone).Length(0, 128);
		}

		public virtual void IsAdultRules()
		{
			this.RuleFor(x => x.IsAdult).NotNull();
		}

		public virtual void BirthdayRules()
		{
			this.RuleFor(x => x.Birthday).NotNull();
		}

		public virtual void FamilyIdRules()
		{
			this.RuleFor(x => x.FamilyId).NotNull();
			this.RuleFor(x => x.FamilyId).Must(this.BeValidFamily).When(x => x ?.FamilyId != null).WithMessage("Invalid reference");
		}

		public virtual void StudioIdRules()
		{
			this.RuleFor(x => x.StudioId).NotNull();
			this.RuleFor(x => x.StudioId).Must(this.BeValidStudio).When(x => x ?.StudioId != null).WithMessage("Invalid reference");
		}

		public virtual void SmsRemindersEnabledRules()
		{
			this.RuleFor(x => x.SmsRemindersEnabled).NotNull();
		}

		public virtual void EmailRemindersEnabledRules()
		{
			this.RuleFor(x => x.EmailRemindersEnabled).NotNull();
		}

		private bool BeValidFamily(int id)
		{
			return this.FamilyRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidStudio(int id)
		{
			return this.StudioRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>e5671990bb34fe585db3ff6b591f2cc2</Hash>
</Codenesium>*/