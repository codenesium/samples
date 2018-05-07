using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IDeviceActionModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(DeviceActionModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, DeviceActionModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1e84ae84e7e6b756e1bfd11e8d96efa2</Hash>
</Codenesium>*/