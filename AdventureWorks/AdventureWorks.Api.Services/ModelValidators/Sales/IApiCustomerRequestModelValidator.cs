using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCustomerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCustomerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2d3d8ea84ea313ed9360f16d7d706fd6</Hash>
</Codenesium>*/