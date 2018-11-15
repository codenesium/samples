using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiStudentServerRequestModelValidator : AbstractValidator<ApiStudentServerRequestModel>
	{
		private int existingRecordId;

		private IStudentRepository studentRepository;

		public AbstractApiStudentServerRequestModelValidator(IStudentRepository studentRepository)
		{
			this.studentRepository = studentRepository;
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
			this.RuleFor(x => x.Email).NotNull();
			this.RuleFor(x => x.Email).Length(0, 128);
		}

		public virtual void EmailRemindersEnabledRules()
		{
		}

		public virtual void FamilyIdRules()
		{
			this.RuleFor(x => x.FamilyId).MustAsync(this.BeValidFamilyByFamilyId).When(x => !x?.FamilyId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull();
			this.RuleFor(x => x.FirstName).Length(0, 128);
		}

		public virtual void IsAdultRules()
		{
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

		public virtual void SmsRemindersEnabledRules()
		{
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUserByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidFamilyByFamilyId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.studentRepository.FamilyByFamilyId(id);

			return record != null;
		}

		private async Task<bool> BeValidUserByUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.studentRepository.UserByUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>2b50bbf61da83969696e5f1a4459680d</Hash>
</Codenesium>*/