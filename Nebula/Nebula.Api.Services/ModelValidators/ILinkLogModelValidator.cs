using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Services
{
	public interface IApiLinkLogRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkLogRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkLogRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>57c19fcbad5d64f7a39d71c66d8582ec</Hash>
</Codenesium>*/