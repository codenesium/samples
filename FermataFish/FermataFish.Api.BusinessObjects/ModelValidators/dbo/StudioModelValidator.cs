using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiStudioRequestModelValidator: AbstractApiStudioRequestModelValidator, IApiStudioRequestModelValidator
	{
		public ApiStudioRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiStudioRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.NameRules();
			this.StateIdRules();
			this.WebsiteRules();
			this.ZipRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.NameRules();
			this.StateIdRules();
			this.WebsiteRules();
			this.ZipRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>9233c67162d28364420a5d48dd6b0b98</Hash>
</Codenesium>*/