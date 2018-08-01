using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public interface IApiClaspRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClaspRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClaspRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>da98f08d186cfc8310fecd7ea5f3da96</Hash>
</Codenesium>*/