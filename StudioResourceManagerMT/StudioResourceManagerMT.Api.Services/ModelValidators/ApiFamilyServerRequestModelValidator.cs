using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiFamilyServerRequestModelValidator : AbstractApiFamilyServerRequestModelValidator, IApiFamilyServerRequestModelValidator
	{
		public ApiFamilyServerRequestModelValidator(IFamilyRepository familyRepository)
			: base(familyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFamilyServerRequestModel model)
		{
			this.NoteRules();
			this.PrimaryContactEmailRules();
			this.PrimaryContactFirstNameRules();
			this.PrimaryContactLastNameRules();
			this.PrimaryContactPhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyServerRequestModel model)
		{
			this.NoteRules();
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
	}
}

/*<Codenesium>
    <Hash>ec841c3e9eb1a99678fc7eac5895f43a</Hash>
</Codenesium>*/