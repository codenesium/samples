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
    <Hash>747225b79eb8ffc95d8d2c32fe02400f</Hash>
</Codenesium>*/