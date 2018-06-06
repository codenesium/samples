using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductDescriptionRequestModelValidator: AbstractApiProductDescriptionRequestModelValidator, IApiProductDescriptionRequestModelValidator
	{
		public ApiProductDescriptionRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>5f88ce987574df0aa2f3b05d2c00ddaa</Hash>
</Codenesium>*/