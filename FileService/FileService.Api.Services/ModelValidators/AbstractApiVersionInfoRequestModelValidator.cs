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
	public abstract class AbstractApiVersionInfoRequestModelValidator: AbstractValidator<ApiVersionInfoRequestModel>
	{
		private long existingRecordId;

		public new ValidationResult Validate(ApiVersionInfoRequestModel model, long id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiVersionInfoRequestModel model, long id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public virtual void AppliedOnRules()
		{                       }

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).Length(0, 1024);
		}
	}
}

/*<Codenesium>
    <Hash>8388c12ec0a2b15d7903b2cfae71aa07</Hash>
</Codenesium>*/