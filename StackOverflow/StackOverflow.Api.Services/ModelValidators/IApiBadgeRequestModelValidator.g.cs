using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiBadgeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBadgeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a2e36df06becce30d0d3c615368bd7c3</Hash>
</Codenesium>*/