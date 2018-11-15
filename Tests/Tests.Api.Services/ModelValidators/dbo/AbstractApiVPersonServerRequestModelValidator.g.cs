using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiVPersonServerRequestModelValidator : AbstractValidator<ApiVPersonServerRequestModel>
	{
		private int existingRecordId;

		private IVPersonRepository vPersonRepository;

		public AbstractApiVPersonServerRequestModelValidator(IVPersonRepository vPersonRepository)
		{
			this.vPersonRepository = vPersonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVPersonServerRequestModel model, int id)
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
    <Hash>768a17a8fdd47057ac6d80750b19f6ae</Hash>
</Codenesium>*/