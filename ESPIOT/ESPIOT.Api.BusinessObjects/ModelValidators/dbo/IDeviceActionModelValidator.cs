using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IDeviceActionModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(DeviceActionModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, DeviceActionModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0ee0d0d22a99c0f9312647665f203bc4</Hash>
</Codenesium>*/