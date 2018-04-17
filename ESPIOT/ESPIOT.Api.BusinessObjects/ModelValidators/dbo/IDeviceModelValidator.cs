using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IDeviceModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(DeviceModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, DeviceModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a5b1e58b03699c271a951a3c0a383eaa</Hash>
</Codenesium>*/