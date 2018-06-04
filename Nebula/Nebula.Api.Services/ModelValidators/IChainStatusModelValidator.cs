using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Services
{
	public interface IApiChainStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainStatusRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatusRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d8966e4aac36c4fed0a280370b65b90d</Hash>
</Codenesium>*/