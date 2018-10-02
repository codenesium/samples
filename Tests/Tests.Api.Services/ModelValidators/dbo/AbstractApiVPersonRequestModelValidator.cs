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
	public abstract class AbstractApiVPersonRequestModelValidator : AbstractValidator<ApiVPersonRequestModel>
	{
		private int existingRecordId;

		private IVPersonRepository vPersonRepository;

		public AbstractApiVPersonRequestModelValidator(IVPersonRepository vPersonRepository)
		{
			this.vPersonRepository = vPersonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVPersonRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PersonNameRules()
		{
			this.RuleFor(x => x.PersonName).NotNull();
			this.RuleFor(x => x.PersonName).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>597b0f40e7bce4382dac6783b23743d0</Hash>
</Codenesium>*/