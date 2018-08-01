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
    <Hash>e7e42499715238c236d5c44b9f60547b</Hash>
</Codenesium>*/