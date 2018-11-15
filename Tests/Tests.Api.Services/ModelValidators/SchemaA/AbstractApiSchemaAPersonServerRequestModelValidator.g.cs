using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>7a433038a5d6eb28ae4224dd1ae876cc</Hash>
</Codenesium>*/