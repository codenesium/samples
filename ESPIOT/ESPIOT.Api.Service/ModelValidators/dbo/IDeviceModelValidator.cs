using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.Service
{
	public interface IDeviceModelValidator
	{
		ValidationResult Validate(DeviceModel entity);

		Task<ValidationResult> ValidateAsync(DeviceModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>0ed6a5457f019d7890be2700b9f7f5a8</Hash>
</Codenesium>*/