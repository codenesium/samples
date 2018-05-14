using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiSpaceFeatureModelValidator: AbstractApiSpaceFeatureModelValidator, IApiSpaceFeatureModelValidator
	{
		public ApiSpaceFeatureModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureModel model)
		{
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureModel model)
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
    <Hash>14df11e3ebd2ec9b01666efae18ac315</Hash>
</Codenesium>*/