using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IApiUsersRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUsersRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiUsersRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fd58168fa47c334df7605de42e3914c7</Hash>
</Codenesium>*/