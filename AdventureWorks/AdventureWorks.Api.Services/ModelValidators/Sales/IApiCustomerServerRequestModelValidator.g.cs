using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCustomerServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCustomerServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>24dc8bee36a24e37e61eda58717e489e</Hash>
</Codenesium>*/