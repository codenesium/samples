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
	public abstract class AbstractApiDepartmentRequestModelValidator: AbstractValidator<ApiDepartmentRequestModel>
	{
		private short existingRecordId;

		public new ValidationResult Validate(ApiDepartmentRequestModel model, short id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDepartmentRequestModel model, short id)
		{
			this.existingRecordId = id;
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
			Department record = await this.DepartmentRepository.GetName(model.Name);

			if(record == null || record.DepartmentID == this.existingRecordId)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>3b53264c1ba8a6cc6d16aabcc903ab5f</Hash>
</Codenesium>*/