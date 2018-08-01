using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractApiVersionInfoRequestModelValidator : AbstractValidator<ApiVersionInfoRequestModel>
	{
		private long existingRecordId;

		private IVersionInfoRepository versionInfoRepository;

		public AbstractApiVersionInfoRequestModelValidator(IVersionInfoRepository versionInfoRepository)
		{
			this.versionInfoRepository = versionInfoRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVersionInfoRequestModel model, long id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AppliedOnRules()
		{
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).Length(0, 1024);
		}
	}
}

/*<Codenesium>
    <Hash>234cb2cdc0b514308b1710764e9e855a</Hash>
</Codenesium>*/