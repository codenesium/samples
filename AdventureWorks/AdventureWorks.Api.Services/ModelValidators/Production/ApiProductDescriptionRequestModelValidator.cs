using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductDescriptionRequestModelValidator : AbstractApiProductDescriptionRequestModelValidator, IApiProductDescriptionRequestModelValidator
	{
		public ApiProductDescriptionRequestModelValidator(IProductDescriptionRepository productDescriptionRepository)
			: base(productDescriptionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductDescriptionRequestModel model)
		{
			this.DescriptionRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDescriptionRequestModel model)
		{
			this.DescriptionRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>3eab6ace59c042f76a457ad0fd40c485</Hash>
</Codenesium>*/