using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiSalesPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c246cfb8a6eca90fbea83689cecf5e78</Hash>
</Codenesium>*/