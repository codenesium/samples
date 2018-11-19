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
	public abstract class AbstractApiSchemaAPersonServerRequestModelValidator : AbstractValidator<ApiSchemaAPersonServerRequestModel>
	{
		private int existingRecordId;

		private ISchemaAPersonRepository schemaAPersonRepository;

		public AbstractApiSchemaAPersonServerRequestModelValidator(ISchemaAPersonRepository schemaAPersonRepository)
		{
			this.schemaAPersonRepository = schemaAPersonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSchemaAPersonServerRequestModel model, int id)
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
    <Hash>c77e6762358d7d87915d8e511366731d</Hash>
</Codenesium>*/