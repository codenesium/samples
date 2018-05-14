using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IApiDeviceModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>51fb0c5b7ce7f2450b1ec5329922f617</Hash>
</Codenesium>*/