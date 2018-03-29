using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractDatabaseLogModelValidator: AbstractValidator<DatabaseLogModel>
	{
		public new ValidationResult Validate(DatabaseLogModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(DatabaseLogModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void PostTimeRules()
		{
			RuleFor(x => x.PostTime).NotNull();
		}

		public virtual void DatabaseUserRules()
		{
			RuleFor(x => x.DatabaseUser).NotNull();
			RuleFor(x => x.DatabaseUser).Length(0,128);
		}

		public virtual void @EventRules()
		{
			RuleFor(x => x.@Event).NotNull();
			RuleFor(x => x.@Event).Length(0,128);
		}

		public virtual void SchemaRules()
		{
			RuleFor(x => x.Schema).Length(0,128);
		}

		public virtual void @ObjectRules()
		{
			RuleFor(x => x.@Object).Length(0,128);
		}

		public virtual void TSQLRules()
		{
			RuleFor(x => x.TSQL).NotNull();
		}

		public virtual void XmlEventRules()
		{
			RuleFor(x => x.XmlEvent).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>74dd5ee7061c4d279adc5bb58a58b3b0</Hash>
</Codenesium>*/