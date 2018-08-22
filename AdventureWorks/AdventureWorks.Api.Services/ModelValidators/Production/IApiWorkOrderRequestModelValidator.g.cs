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
    <Hash>10053782a4ec328b7a477f2dc890effb</Hash>
</Codenesium>*/