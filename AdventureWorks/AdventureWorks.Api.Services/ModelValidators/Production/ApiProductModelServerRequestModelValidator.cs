using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductModelServerRequestModelValidator : AbstractApiProductModelServerRequestModelValidator, IApiProductModelServerRequestModelValidator
	{
		public ApiProductModelServerRequestModelValidator(IProductModelRepository productModelRepository)
			: base(productModelRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductModelServerRequestModel model)
		{
			this.CatalogDescriptionRules();
			this.InstructionRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelServerRequestModel model)
		{
			this.CatalogDescriptionRules();
			this.InstructionRules();
			this.ModifiedDateRules();
			this.NameRules();
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
    <Hash>670733b2fda8562a4535592d9fb1ecaf</Hash>
</Codenesium>*/