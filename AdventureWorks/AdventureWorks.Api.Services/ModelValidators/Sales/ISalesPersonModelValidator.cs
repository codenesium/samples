using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>5fe6ba5cc2eb60904833e2f6dda38349</Hash>
</Codenesium>*/