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
	public class ApiFamilyServerRequestModelValidator : AbstractValidator<ApiFamilyServerRequestModel>, IApiFamilyServerRequestModelValidator
	{
		private int existingRecordId;

		protected IFamilyRepository FamilyRepository { get; private set; }

		public ApiFamilyServerRequestModelValidator(IFamilyRepository familyRepository)
		{
			this.FamilyRepository = familyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFamilyServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFamilyServerRequestModel model)
		{
			this.NotesRules();
			this.PrimaryContactEmailRules();
			this.PrimaryContactFirstNameRules();
			this.PrimaryContactLastNameRules();
			this.PrimaryContactPhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyServerRequestModel model)
		{
			this.NotesRules();
			this.PrimaryContactEmailRules();
			this.PrimaryContactFirstNameRules();
			this.PrimaryContactLastNameRules();
			this.PrimaryContactPhoneRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void NotesRules()
		{
			this.RuleFor(x => x.Notes).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
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
    <Hash>92c3424655f9d3a74389b8beca8bc328</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/