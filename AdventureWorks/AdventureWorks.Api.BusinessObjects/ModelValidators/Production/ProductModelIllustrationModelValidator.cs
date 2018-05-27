using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductModelIllustrationRequestModelValidator: AbstractApiProductModelIllustrationRequestModelValidator, IApiProductModelIllustrationRequestModelValidator
	{
		public ApiProductModelIllustrationRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductModelIllustrationRequestModel model)
		{
			this.IllustrationIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelIllustrationRequestModel model)
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
    <Hash>96222bb7cc7dc15eb2514e658d23f68c</Hash>
</Codenesium>*/