using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public interface IApiTimestampCheckRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTimestampCheckRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTimestampCheckRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fb7672e54f4c3fe7debb8ffd03b05d46</Hash>
</Codenesium>*/