using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductModelRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4d960703c34722d9fd8438c69e94aa6a</Hash>
</Codenesium>*/