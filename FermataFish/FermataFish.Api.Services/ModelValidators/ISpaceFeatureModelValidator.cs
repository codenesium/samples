using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Services
{
	public interface IApiSpaceFeatureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f455f8e49bdfadb4d2028bc395b31b61</Hash>
</Codenesium>*/