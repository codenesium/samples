using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service

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
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,255);
		}
	}
}

/*<Codenesium>
    <Hash>d1c47471b40e1c67fe4a5a2ef50da59b</Hash>
</Codenesium>*/