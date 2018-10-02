using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e13d8235909fd0792803d4febc4c7127</Hash>
</Codenesium>*/