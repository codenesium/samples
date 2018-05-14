using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductProductPhotoModelValidator: AbstractApiProductProductPhotoModelValidator, IApiProductProductPhotoModelValidator
	{
		public ApiProductProductPhotoModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductProductPhotoModel model)
		{
			this.ModifiedDateRules();
			this.PrimaryRules();
			this.ProductPhotoIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductProductPhotoModel model)
		{
			this.ModifiedDateRules();
			this.PrimaryRules();
			this.ProductPhotoIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>273b5282a087ed5266ad277f45bdc6fc</Hash>
</Codenesium>*/