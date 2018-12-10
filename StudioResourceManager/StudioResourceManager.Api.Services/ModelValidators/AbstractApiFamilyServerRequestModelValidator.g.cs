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
	public abstract class AbstractApiFamilyServerRequestModelValidator : AbstractValidator<ApiFamilyServerRequestModel>
	{
		private int existingRecordId;

		protected IFamilyRepository FamilyRepository { get; private set; }

		public AbstractApiFamilyServerRequestModelValidator(IFamilyRepository familyRepository)
		{
			this.FamilyRepository = familyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFamilyServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PrimaryContactEmailRules()
		{
			this.RuleFor(x => x.PrimaryContactEmail).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PrimaryContactFirstNameRules()
		{
			this.RuleFor(x => x.PrimaryContactFirstName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PrimaryContactLastNameRules()
		{
			this.RuleFor(x => x.PrimaryContactLastName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PrimaryContactPhoneRules()
		{
			this.RuleFor(x => x.PrimaryContactPhone).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.PrimaryContactPhone).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>69a0a6f12e95f22a0e01293a7a263f17</Hash>
</Codenesium>*/