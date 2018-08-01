using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IApiBadgesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBadgesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>45e2ceec65b711f925eba1ca633a3d1a</Hash>
</Codenesium>*/