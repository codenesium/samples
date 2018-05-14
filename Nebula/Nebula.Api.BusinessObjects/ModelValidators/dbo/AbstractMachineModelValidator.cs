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
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>cd02366d28283e7416fb44ceac6dd964</Hash>
</Codenesium>*/