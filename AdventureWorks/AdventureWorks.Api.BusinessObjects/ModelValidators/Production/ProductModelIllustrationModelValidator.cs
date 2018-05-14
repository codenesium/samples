using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductModelIllustrationModelValidator: AbstractApiProductModelIllustrationModelValidator, IApiProductModelIllustrationModelValidator
	{
		public ApiProductModelIllustrationModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductModelIllustrationModel model)
		{
			this.IllustrationIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelIllustrationModel model)
		{
			this.IllustrationIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>d3a4370a02da6ac337ab744aae74cdc3</Hash>
</Codenesium>*/