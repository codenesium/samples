using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostTypesServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostTypesServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostTypesServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b59c2941b46283a20c866ba7e31af61d</Hash>
</Codenesium>*/