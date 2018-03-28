using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service

{
	public abstract class AbstractMachineModelValidator: AbstractValidator<MachineModel>
	{
		public new ValidationResult Validate(MachineModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(MachineModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}

		public virtual void MachineGuidRules()
		{
			RuleFor(x => x.MachineGuid).NotNull();
		}

		public virtual void JwtKeyRules()
		{
			RuleFor(x => x.JwtKey).NotNull();
			RuleFor(x => x.JwtKey).Length(0,128);
		}

		public virtual void LastIpAddressRules()
		{
			RuleFor(x => x.LastIpAddress).NotNull();
			RuleFor(x => x.LastIpAddress).Length(0,128);
		}

		public virtual void DescriptionRules()
		{
			RuleFor(x => x.Description).NotNull();
			RuleFor(x => x.Description).Length(0,2147483647);
		}
	}
}

/*<Codenesium>
    <Hash>f880ec036a4739b7b4e94d68ae3a8242</Hash>
</Codenesium>*/