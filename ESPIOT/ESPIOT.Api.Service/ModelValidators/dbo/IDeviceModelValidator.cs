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
    <Hash>c30cdbba4181089d9d615aba8b00ef76</Hash>
</Codenesium>*/