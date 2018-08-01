using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiScrapReasonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiScrapReasonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(short id, ApiScrapReasonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>22369d5d0e904e4f0b6f75fc71240685</Hash>
</Codenesium>*/