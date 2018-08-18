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
	public abstract class AbstractApiDatabaseLogRequestModelValidator : AbstractValidator<ApiDatabaseLogRequestModel>
	{
		private int existingRecordId;

		private IDatabaseLogRepository databaseLogRepository;

		public AbstractApiDatabaseLogRequestModelValidator(IDatabaseLogRepository databaseLogRepository)
		{
			this.databaseLogRepository = databaseLogRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDatabaseLogRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DatabaseUserRules()
		{
			this.RuleFor(x => x.DatabaseUser).NotNull();
			this.RuleFor(x => x.DatabaseUser).Length(0, 128);
		}

		public virtual void @EventRules()
		{
			this.RuleFor(x => x.@Event).NotNull();
			this.RuleFor(x => x.@Event).Length(0, 128);
		}

		public virtual void @ObjectRules()
		{
			this.RuleFor(x => x.@Object).Length(0, 128);
		}

		public virtual void PostTimeRules()
		{
		}

		public virtual void SchemaRules()
		{
			this.RuleFor(x => x.Schema).Length(0, 128);
		}

		public virtual void TsqlRules()
		{
			this.RuleFor(x => x.Tsql).NotNull();
		}

		public virtual void XmlEventRules()
		{
			this.RuleFor(x => x.XmlEvent).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>31b983b68936e9ebab1d5cf9feb16cc3</Hash>
</Codenesium>*/