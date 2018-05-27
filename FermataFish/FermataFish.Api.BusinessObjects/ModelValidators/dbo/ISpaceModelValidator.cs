using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiSpaceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e356887a6c6b96429b8e719b6a198bca</Hash>
</Codenesium>*/