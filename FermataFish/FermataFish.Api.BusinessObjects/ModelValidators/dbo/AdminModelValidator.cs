using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class AdminModelValidator: AbstractAdminModelValidator, IAdminModelValidator
	{
		public AdminModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(AdminModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.BirthdayRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, AdminModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.BirthdayRules();
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
    <Hash>163c7a01449758e21db95c27aa10021e</Hash>
</Codenesium>*/