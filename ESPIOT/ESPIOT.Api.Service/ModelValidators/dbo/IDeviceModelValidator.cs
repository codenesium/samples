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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>8d3b583075619af9527e277d4620cef4</Hash>
</Codenesium>*/