using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiDatabaseLogRequestModelValidator: AbstractValidator<ApiDatabaseLogRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiDatabaseLogRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDatabaseLogRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
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
			this.RuleFor(x => x.PostTime).NotNull();
		}

		public virtual void SchemaRules()
		{
			this.RuleFor(x => x.Schema).Length(0, 128);
		}

		public virtual void TSQLRules()
		{
			this.RuleFor(x => x.TSQL).NotNull();
		}

		public virtual void XmlEventRules()
		{
			this.RuleFor(x => x.XmlEvent).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>82e709d31b755692dabeb2e2bdce2dbb</Hash>
</Codenesium>*/