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
    <Hash>b3830c5dd37d728e50ac764c178ac123</Hash>
</Codenesium>*/