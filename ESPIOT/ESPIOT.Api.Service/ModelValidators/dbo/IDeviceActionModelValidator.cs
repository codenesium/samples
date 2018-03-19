using System.Threading.Tasks;
using FluentValidation.Results;

using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.Service
{
	public interface IDeviceActionModelValidator
	{
		ValidationResult Validate(DeviceActionModel entity);

		Task<ValidationResult> ValidateAsync(DeviceActionModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>d0aeb941589e7a7c63be642e076d61ee</Hash>
</Codenesium>*/