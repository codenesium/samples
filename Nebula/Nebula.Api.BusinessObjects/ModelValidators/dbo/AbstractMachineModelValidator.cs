using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractApiMachineModelValidator: AbstractValidator<ApiMachineModel>
	{
		public new ValidationResult Validate(ApiMachineModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiMachineModel model)
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
			this.RuleFor(x => x).Must(this.BeUniqueGetMachineGuid).When(x => x ?.MachineGuid != null).WithMessage("Violates unique constraint").WithName(nameof(ApiMachineModel.MachineGuid));
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private bool BeUniqueGetMachineGuid(ApiMachineModel model)
		{
			return this.MachineRepository.GetMachineGuid(model.MachineGuid) == null;
		}
	}
}

/*<Codenesium>
    <Hash>311166ef08718ae2cbd00a82c3bf8def</Hash>
</Codenesium>*/