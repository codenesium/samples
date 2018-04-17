using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class FamilyModelValidator: AbstractFamilyModelValidator, IFamilyModelValidator
	{
		public FamilyModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(FamilyModel model)
		{
			this.PcFirstNameRules();
			this.PcLastNameRules();
			this.PcPhoneRules();
			this.PcEmailRules();
			this.NotesRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, FamilyModel model)
		{
			this.PcFirstNameRules();
			this.PcLastNameRules();
			this.PcPhoneRules();
			this.PcEmailRules();
			this.NotesRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>505f176cd06b755849101a0a63e4a06b</Hash>
</Codenesium>*/