using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiPersonTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>455328f78ca62306e82bcdce841f7f97</Hash>
</Codenesium>*/