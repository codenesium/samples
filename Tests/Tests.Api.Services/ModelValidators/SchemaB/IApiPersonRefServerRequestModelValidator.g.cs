using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiPersonRefServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonRefServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRefServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6a9107e18971c8dc6a89db9372b4404f</Hash>
</Codenesium>*/