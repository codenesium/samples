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
	public class ChainStatusModelValidatorAbstract: AbstractValidator<ChainStatusModel>
	{
		public virtual void IdRules()
		{
			RuleFor(x => x.Id).NotNull();
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}
	}
}

/*<Codenesium>
    <Hash>8898cf0ad07ac45ded18671aa7d42003</Hash>
</Codenesium>*/