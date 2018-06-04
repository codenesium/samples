using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiClientRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClientRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c99535e94f3818152d5f570a05df1479</Hash>
</Codenesium>*/