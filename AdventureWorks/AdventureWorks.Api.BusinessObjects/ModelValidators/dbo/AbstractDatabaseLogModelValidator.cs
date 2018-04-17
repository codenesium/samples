using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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
			this.RuleFor(x => x.PostTime).NotNull();
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

		public virtual void SchemaRules()
		{
			this.RuleFor(x => x.Schema).Length(0, 128);
		}

		public virtual void @ObjectRules()
		{
			this.RuleFor(x => x.@Object).Length(0, 128);
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
    <Hash>c18a5736eb5d2f919c685a0fe08325b4</Hash>
</Codenesium>*/