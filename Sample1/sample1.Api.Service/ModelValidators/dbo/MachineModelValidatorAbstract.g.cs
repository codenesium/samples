using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

using sample1NS.Api.Contracts;
using sample1NS.Api.DataAccess;

namespace sample1NS.Api.Service

{
	public class MachineModelValidatorAbstract: AbstractValidator<MachineModel>
	{
		public virtual void DescriptionRules()
		{
			RuleFor(x => x.Description).NotNull();
			RuleFor(x => x.Description).Length(0,2147483647);
		}

		public virtual void IdRules()
		{
			RuleFor(x => x.Id).NotNull();
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

		public virtual void MachineGuidRules()
		{
			RuleFor(x => x.MachineGuid).NotNull();
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}
	}
}

/*<Codenesium>
    <Hash>f9dd0502bf769cbb07bebbbfa3e8e2ca</Hash>
</Codenesium>*/