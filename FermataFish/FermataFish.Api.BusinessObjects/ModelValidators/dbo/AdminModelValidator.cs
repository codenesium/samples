using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiAdminModelValidator: AbstractApiAdminModelValidator, IApiAdminModelValidator
	{
		public ApiAdminModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiAdminModel model)
		{
			this.BirthdayRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminModel model)
		{
			this.BirthdayRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
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
    <Hash>689d7f4d1e1405d5f56aca4104b1612c</Hash>
</Codenesium>*/