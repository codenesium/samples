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

		protected ISchemaBPersonRepository SchemaBPersonRepository { get; private set; }

		public AbstractApiSchemaBPersonServerRequestModelValidator(ISchemaBPersonRepository schemaBPersonRepository)
		{
			this.SchemaBPersonRepository = schemaBPersonRepository;
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
    <Hash>833465671c18e0af892908f99d2d4083</Hash>
</Codenesium>*/