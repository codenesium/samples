using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
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
    <Hash>d3ec23020cacb50325e8a1ce484e85b0</Hash>
</Codenesium>*/