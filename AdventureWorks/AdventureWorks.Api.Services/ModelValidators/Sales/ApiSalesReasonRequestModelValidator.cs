using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesReasonRequestModelValidator : AbstractApiSalesReasonRequestModelValidator, IApiSalesReasonRequestModelValidator
	{
		public ApiSalesReasonRequestModelValidator(ISalesReasonRepository salesReasonRepository)
			: base(salesReasonRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesReasonRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ReasonTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesReasonRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ReasonTypeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>7a03d3a1ab03a509dd0db2744063da47</Hash>
</Codenesium>*/