using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>8b7173eb82d855fa9c5735dc13317c33</Hash>
</Codenesium>*/