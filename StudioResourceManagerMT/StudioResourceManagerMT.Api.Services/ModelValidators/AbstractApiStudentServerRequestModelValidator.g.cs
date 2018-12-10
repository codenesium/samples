using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiStudentServerRequestModelValidator : AbstractValidator<ApiStudentServerRequestModel>
	{
		private int existingRecordId;

		protected IStudentRepository StudentRepository { get; private set; }

		public AbstractApiStudentServerRequestModelValidator(IStudentRepository studentRepository)
		{
			this.StudentRepository = studentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiStudentServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BirthdayRules()
		{
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Email).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void EmailRemindersEnabledRules()
		{
		}

		public virtual void FamilyIdRules()
		{
			this.RuleFor(x => x.FamilyId).MustAsync(this.BeValidFamilyByFamilyId).When(x => !x?.FamilyId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FirstName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void IsAdultRules()
		{
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.LastName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Phone).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void SmsRemindersEnabledRules()
		{
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUserByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidFamilyByFamilyId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.StudentRepository.FamilyByFamilyId(id);

			return record != null;
		}

		protected async Task<bool> BeValidUserByUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.StudentRepository.UserByUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>0b79e1445c37014570e8e242714a54e4</Hash>
</Codenesium>*/