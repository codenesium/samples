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
	public abstract class AbstractApiSchemaBPersonRequestModelValidator : AbstractValidator<ApiSchemaBPersonRequestModel>
	{
		private int existingRecordId;

		private ISchemaBPersonRepository schemaBPersonRepository;

		public AbstractApiSchemaBPersonRequestModelValidator(ISchemaBPersonRepository schemaBPersonRepository)
		{
			this.schemaBPersonRepository = schemaBPersonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSchemaBPersonRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>20d88d06b919fd36d3130d6bb473217a</Hash>
</Codenesium>*/