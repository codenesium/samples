using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiDatabaseLogServerRequestModelValidator : AbstractValidator<ApiDatabaseLogServerRequestModel>
	{
		private int existingRecordId;

		protected IDatabaseLogRepository DatabaseLogRepository { get; private set; }

		public AbstractApiDatabaseLogServerRequestModelValidator(IDatabaseLogRepository databaseLogRepository)
		{
			this.DatabaseLogRepository = databaseLogRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDatabaseLogServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DatabaseUserRules()
		{
			this.RuleFor(x => x.DatabaseUser).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.DatabaseUser).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ReservedEventRules()
		{
			this.RuleFor(x => x.ReservedEvent).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.ReservedEvent).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ReservedObjectRules()
		{
			this.RuleFor(x => x.ReservedObject).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PostTimeRules()
		{
		}

		public virtual void SchemaRules()
		{
			this.RuleFor(x => x.Schema).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TsqlRules()
		{
			this.RuleFor(x => x.Tsql).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
		}

		public virtual void XmlEventRules()
		{
			this.RuleFor(x => x.XmlEvent).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
		}
	}
}

/*<Codenesium>
    <Hash>52e06faabab86fc464dc5285b9999795</Hash>
</Codenesium>*/