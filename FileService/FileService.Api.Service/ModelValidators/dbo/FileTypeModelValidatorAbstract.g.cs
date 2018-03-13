using FluentValidation;
using System;

using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service

{
	public class FileTypeModelValidatorAbstract: AbstractValidator<FileTypeModel>
	{
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
    <Hash>6332bf7ac19654f1a660b2803474e9a4</Hash>
</Codenesium>*/