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
	public abstract class AbstractApiSchemaBPersonServerRequestModelValidator : AbstractValidator<ApiSchemaBPersonServerRequestModel>
	{
		private int existingRecordId;

		private ISchemaBPersonRepository schemaBPersonRepository;

		public AbstractApiSchemaBPersonServerRequestModelValidator(ISchemaBPersonRepository schemaBPersonRepository)
		{
			this.schemaBPersonRepository = schemaBPersonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSchemaBPersonServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>514fd0f0df1a4d5d44ad7a5246ae8433</Hash>
</Codenesium>*/