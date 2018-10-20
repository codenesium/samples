using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiFamilyRequestModelValidator : AbstractApiFamilyRequestModelValidator, IApiFamilyRequestModelValidator
	{
		public ApiFamilyRequestModelValidator(IFamilyRepository familyRepository)
			: base(familyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFamilyRequestModel model)
		{
			this.NoteRules();
			this.PrimaryContactEmailRules();
			this.PrimaryContactFirstNameRules();
			this.PrimaryContactLastNameRules();
			this.PrimaryContactPhoneRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyRequestModel model)
		{
			this.NoteRules();
			this.PrimaryContactEmailRules();
			this.PrimaryContactFirstNameRules();
			this.PrimaryContactLastNameRules();
			this.PrimaryContactPhoneRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>8beb32ce6302301e13d6481a8543e1ae</Hash>
</Codenesium>*/