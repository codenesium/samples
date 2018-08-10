using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiWorkOrderRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>51bf496386c0e60bc64c80a93afeef18</Hash>
</Codenesium>*/