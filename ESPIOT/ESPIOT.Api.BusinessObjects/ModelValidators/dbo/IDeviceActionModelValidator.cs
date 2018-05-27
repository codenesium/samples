using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IApiDeviceActionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceActionRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceActionRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6fdead9ca2625de01a9cb64ca58b5581</Hash>
</Codenesium>*/