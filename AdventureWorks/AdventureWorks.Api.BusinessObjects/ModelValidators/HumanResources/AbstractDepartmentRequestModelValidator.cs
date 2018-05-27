using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiDepartmentRequestModelValidator: AbstractValidator<ApiDepartmentRequestModel>
	{
		public new ValidationResult Validate(ApiDepartmentRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDepartmentRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IDepartmentRepository DepartmentRepository { get; set; }
		public virtual void GroupNameRules()
		{
			this.RuleFor(x => x.GroupName).NotNull();
			this.RuleFor(x => x.GroupName).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiDepartmentRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueGetName(ApiDepartmentRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.DepartmentRepository.GetName(model.Name);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>b7f873c8114af861cecd9e8ac75bbbb6</Hash>
</Codenesium>*/