using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiSpaceModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8198fbf14a83a74ec255f0769fd9afe1</Hash>
</Codenesium>*/