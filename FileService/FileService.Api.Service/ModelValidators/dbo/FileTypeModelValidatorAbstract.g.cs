using FluentValidation;
using System;

using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service

{
	public class FileTypeModelValidatorAbstract: AbstractValidator<FileTypeModel>
	{
		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,255);
		}
	}
}

/*<Codenesium>
    <Hash>ad7ad79a547a806e1537cc644e125b02</Hash>
</Codenesium>*/