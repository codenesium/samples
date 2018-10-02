using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiMessageRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMessageRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMessageRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>72aa1dc3e259a9f4052209ca59ce73ee</Hash>
</Codenesium>*/