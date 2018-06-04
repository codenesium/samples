using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductModelIllustrationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelIllustrationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelIllustrationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f42d2420d5306e59e7cb7e90820d7e49</Hash>
</Codenesium>*/