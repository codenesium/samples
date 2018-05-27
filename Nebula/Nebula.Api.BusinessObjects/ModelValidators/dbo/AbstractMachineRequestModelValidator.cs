using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractApiMachineRequestModelValidator: AbstractValidator<ApiMachineRequestModel>
	{
		public new ValidationResult Validate(ApiMachineRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiMachineRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IMachineRepository MachineRepository { get; set; }
		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull();
			this.RuleFor(x => x.Description).Length(0, 2147483647);
		}

		public virtual void JwtKeyRules()
		{
			this.RuleFor(x => x.JwtKey).NotNull();
			this.RuleFor(x => x.JwtKey).Length(0, 128);
		}

		public virtual void LastIpAddressRules()
		{
			this.RuleFor(x => x.LastIpAddress).NotNull();
			this.RuleFor(x => x.LastIpAddress).Length(0, 128);
		}

		public virtual void MachineGuidRules()
		{
			this.RuleFor(x => x.MachineGuid).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetMachineGuid).When(x => x ?.MachineGuid != null).WithMessage("Violates unique constraint").WithName(nameof(ApiMachineRequestModel.MachineGuid));
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeUniqueGetMachineGuid(ApiMachineRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.MachineRepository.GetMachineGuid(model.MachineGuid);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>de0bb159bfb8e60493b4c62c5d00c996</Hash>
</Codenesium>*/