using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiTeacherServerRequestModelValidator : AbstractValidator<ApiTeacherServerRequestModel>
	{
		private int existingRecordId;

		protected ITeacherRepository TeacherRepository { get; private set; }

		public AbstractApiTeacherServerRequestModelValidator(ITeacherRepository teacherRepository)
		{
			this.TeacherRepository = teacherRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeacherServerRequestModel model, int id)
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

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FirstName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.LastName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUserByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidUserByUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TeacherRepository.UserByUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>ddefb7ccc3da11b9d40233394504b054</Hash>
</Codenesium>*/