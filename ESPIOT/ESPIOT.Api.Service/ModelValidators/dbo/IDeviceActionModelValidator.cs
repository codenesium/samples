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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>451076a91501b2a605f39426857b37c0</Hash>
</Codenesium>*/