using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiRowVersionCheckRequestModelValidator : AbstractValidator<ApiRowVersionCheckRequestModel>
	{
		private int existingRecordId;

		private IRowVersionCheckRepository rowVersionCheckRepository;

		public AbstractApiRowVersionCheckRequestModelValidator(IRowVersionCheckRepository rowVersionCheckRepository)
		{
			this.rowVersionCheckRepository = rowVersionCheckRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiRowVersionCheckRequestModel model, int id)
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
    <Hash>de11d16ad9deead2182c6d79b88ed513</Hash>
</Codenesium>*/