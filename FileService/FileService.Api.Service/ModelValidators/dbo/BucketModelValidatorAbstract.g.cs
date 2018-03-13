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

		public virtual void IdRules()
		{
			RuleFor(x => x.Id).NotNull();
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,255);
		}
	}
}

/*<Codenesium>
    <Hash>77211094c9d2f83e5e593811df20f6b4</Hash>
</Codenesium>*/