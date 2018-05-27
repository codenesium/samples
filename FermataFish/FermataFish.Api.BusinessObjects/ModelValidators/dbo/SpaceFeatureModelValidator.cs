using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiSpaceFeatureRequestModelValidator: AbstractApiSpaceFeatureRequestModelValidator, IApiSpaceFeatureRequestModelValidator
	{
		public ApiSpaceFeatureRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureRequestModel model)
		{
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureRequestModel model)
		{
			this.NameRules();
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
    <Hash>f41276f39b2a422e26d49b4e6d54b35b</Hash>
</Codenesium>*/