using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiRowVersionCheckServerRequestModelValidator : AbstractValidator<ApiRowVersionCheckServerRequestModel>
	{
		private int existingRecordId;

		private IRowVersionCheckRepository rowVersionCheckRepository;

		public AbstractApiRowVersionCheckServerRequestModelValidator(IRowVersionCheckRepository rowVersionCheckRepository)
		{
			this.rowVersionCheckRepository = rowVersionCheckRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiRowVersionCheckServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowVersionRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>41615e0f10ee6b188716c21125161b1d</Hash>
</Codenesium>*/