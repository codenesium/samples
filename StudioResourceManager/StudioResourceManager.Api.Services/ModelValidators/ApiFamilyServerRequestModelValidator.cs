using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>4cb61729dcb340b3577b625f2dcb13dc</Hash>
</Codenesium>*/