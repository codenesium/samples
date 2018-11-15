using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiTagServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTagServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTagServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>35296ce7fc07bf0207156fd30eb7c89e</Hash>
</Codenesium>*/