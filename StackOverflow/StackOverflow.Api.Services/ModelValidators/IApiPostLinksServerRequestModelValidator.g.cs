using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostLinksServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostLinksServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostLinksServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0c8ecf9982f16b35fd93660f8f21f4e9</Hash>
</Codenesium>*/