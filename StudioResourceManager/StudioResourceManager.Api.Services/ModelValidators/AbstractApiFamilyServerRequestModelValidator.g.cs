using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiFamilyServerRequestModelValidator : AbstractValidator<ApiFamilyServerRequestModel>
	{
		private int existingRecordId;

		private IFamilyRepository familyRepository;

		public AbstractApiFamilyServerRequestModelValidator(IFamilyRepository familyRepository)
		{
			this.familyRepository = familyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFamilyServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).Length(0, 2147483647);
		}

		public virtual void PrimaryContactEmailRules()
		{
			this.RuleFor(x => x.PrimaryContactEmail).Length(0, 128);
		}

		public virtual void PrimaryContactFirstNameRules()
		{
			this.RuleFor(x => x.PrimaryContactFirstName).Length(0, 128);
		}

		public virtual void PrimaryContactLastNameRules()
		{
			this.RuleFor(x => x.PrimaryContactLastName).Length(0, 128);
		}

		public virtual void PrimaryContactPhoneRules()
		{
			this.RuleFor(x => x.PrimaryContactPhone).NotNull();
			this.RuleFor(x => x.PrimaryContactPhone).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>23d001e2824b7821921fcca9e3949bee</Hash>
</Codenesium>*/