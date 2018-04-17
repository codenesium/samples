using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.BusinessObjects

{
	public abstract class AbstractDeviceActionModelValidator: AbstractValidator<DeviceActionModel>
	{
		public new ValidationResult Validate(DeviceActionModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(DeviceActionModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IDeviceRepository DeviceRepository { get; set; }
		public virtual void DeviceIdRules()
		{
			this.RuleFor(x => x.DeviceId).NotNull();
			this.RuleFor(x => x.DeviceId).Must(this.BeValidDevice).When(x => x ?.DeviceId != null).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 90);
		}

		public virtual void @ValueRules()
		{
			this.RuleFor(x => x.@Value).NotNull();
			this.RuleFor(x => x.@Value).Length(0, 4000);
		}

		private bool BeValidDevice(int id)
		{
			return this.DeviceRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>18e9ae44e703e9b37e664ce296a7eae9</Hash>
</Codenesium>*/