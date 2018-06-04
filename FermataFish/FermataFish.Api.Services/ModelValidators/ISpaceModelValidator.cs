using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Services
{
	public interface IApiSpaceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e266fb54eb9da2900f7d4b77edcc6ef7</Hash>
</Codenesium>*/