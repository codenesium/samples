using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IDeviceModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(DeviceModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, DeviceModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fa05f3bfaa1904f94ca31754e52afd71</Hash>
</Codenesium>*/