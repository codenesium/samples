using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiWorkOrderRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c76f4f874de41d1b97c33b5a4ac6a299</Hash>
</Codenesium>*/