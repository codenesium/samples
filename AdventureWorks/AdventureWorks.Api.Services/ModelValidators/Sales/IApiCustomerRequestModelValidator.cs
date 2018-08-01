using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiCustomerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCustomerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>83826189b4d0d021da496c53d7b1ad9c</Hash>
</Codenesium>*/