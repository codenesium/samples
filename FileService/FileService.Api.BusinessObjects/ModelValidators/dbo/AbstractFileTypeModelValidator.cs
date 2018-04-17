using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects

{
	public abstract class AbstractFileTypeModelValidator: AbstractValidator<FileTypeModel>
	{
		public new ValidationResult Validate(FileTypeModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(FileTypeModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 255);
		}
	}
}

/*<Codenesium>
    <Hash>b17c3a34af898bef451a94b2c32828db</Hash>
</Codenesium>*/