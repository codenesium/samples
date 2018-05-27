using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiFamilyRequestModelValidator: AbstractApiFamilyRequestModelValidator, IApiFamilyRequestModelValidator
	{
		public ApiFamilyRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiFamilyRequestModel model)
		{
			this.NotesRules();
			this.PcEmailRules();
			this.PcFirstNameRules();
			this.PcLastNameRules();
			this.PcPhoneRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyRequestModel model)
		{
			this.NotesRules();
			this.PcEmailRules();
			this.PcFirstNameRules();
			this.PcLastNameRules();
			this.PcPhoneRules();
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
    <Hash>c9b0aabcd4f6c8e1fb0a6afd61fd8482</Hash>
</Codenesium>*/