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
    <Hash>f7bdf015017c2c8d3a1c5f4ff90b2870</Hash>
</Codenesium>*/