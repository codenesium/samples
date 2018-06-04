using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>a4f8bedeb1de2291951ef9adebb8745d</Hash>
</Codenesium>*/