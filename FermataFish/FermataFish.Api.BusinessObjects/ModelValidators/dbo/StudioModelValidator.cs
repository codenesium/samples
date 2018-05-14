using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiStudioModelValidator: AbstractApiStudioModelValidator, IApiStudioModelValidator
	{
		public ApiStudioModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiStudioModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioModel model)
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
    <Hash>71a3a3066eccacc9e124d89f81815e78</Hash>
</Codenesium>*/