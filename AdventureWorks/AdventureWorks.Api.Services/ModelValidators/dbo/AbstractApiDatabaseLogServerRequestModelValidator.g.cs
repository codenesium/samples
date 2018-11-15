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

		private IDatabaseLogRepository databaseLogRepository;

		public AbstractApiDatabaseLogServerRequestModelValidator(IDatabaseLogRepository databaseLogRepository)
		{
			this.databaseLogRepository = databaseLogRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDatabaseLogServerRequestModel model, int id)
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
    <Hash>0cef7affff9e4eca0e61272ffff9ed75</Hash>
</Codenesium>*/