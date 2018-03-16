using FluentValidation;
using System;

using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service

{
	public class BucketModelValidatorAbstract: AbstractValidator<BucketModel>
	{
		public virtual void ExternalIdRules()
		{
			RuleFor(x => x.ExternalId).NotNull();
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,255);
		}
	}
}

/*<Codenesium>
    <Hash>ed2d0e81b28a5c3738a3a08757d2e420</Hash>
</Codenesium>*/