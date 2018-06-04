using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiPersonCreditCardRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonCreditCardRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonCreditCardRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6fd6384373305221a1158de2d8015111</Hash>
</Codenesium>*/