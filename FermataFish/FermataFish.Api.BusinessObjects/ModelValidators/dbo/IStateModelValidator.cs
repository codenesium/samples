using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiStateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStateRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9741d68ac7dc0f31e0468017687bffc6</Hash>
</Codenesium>*/