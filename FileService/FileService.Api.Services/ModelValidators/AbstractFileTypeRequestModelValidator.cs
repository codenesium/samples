using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Services

{
	public abstract class AbstractApiFileTypeRequestModelValidator: AbstractValidator<ApiFileTypeRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiFileTypeRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiFileTypeRequestModel model, int id)
		{
			this.existingRecordId = id;
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
    <Hash>94e205e8a37b70a14c12593d4d157578</Hash>
</Codenesium>*/