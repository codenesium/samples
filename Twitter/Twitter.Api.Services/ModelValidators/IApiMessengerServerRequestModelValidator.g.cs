using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiMessengerServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMessengerServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMessengerServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>541d066e1f6c5f4d14ab00f89a01d0c9</Hash>
</Codenesium>*/