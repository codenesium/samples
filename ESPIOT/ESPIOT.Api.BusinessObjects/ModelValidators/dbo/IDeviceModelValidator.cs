using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IApiDeviceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f84f8087266e7e966ed0c5e3f850533e</Hash>
</Codenesium>*/