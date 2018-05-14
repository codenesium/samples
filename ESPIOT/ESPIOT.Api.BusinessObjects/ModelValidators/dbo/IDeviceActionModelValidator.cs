using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IApiDeviceActionModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceActionModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceActionModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>045c1deff32cfa65a15a057f54c57670</Hash>
</Codenesium>*/