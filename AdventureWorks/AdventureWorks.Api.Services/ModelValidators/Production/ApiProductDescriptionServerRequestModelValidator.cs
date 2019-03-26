using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductDescriptionServerRequestModelValidator : AbstractApiProductDescriptionServerRequestModelValidator, IApiProductDescriptionServerRequestModelValidator
	{
		public ApiProductDescriptionServerRequestModelValidator(IProductDescriptionRepository productDescriptionRepository)
			: base(productDescriptionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductDescriptionServerRequestModel model)
		{
			this.DescriptionRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDescriptionServerRequestModel model)
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
    <Hash>6c764c28ea5cb205ae8fc57096611869</Hash>
</Codenesium>*/