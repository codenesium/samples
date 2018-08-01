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
	public abstract class AbstractApiEmployeeDepartmentHistoryRequestModelValidator : AbstractValidator<ApiEmployeeDepartmentHistoryRequestModel>
	{
		private int existingRecordId;

		private IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository;

		public AbstractApiEmployeeDepartmentHistoryRequestModelValidator(IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository)
		{
			this.employeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeDepartmentHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DepartmentIDRules()
		{
		}

		public virtual void EndDateRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void ShiftIDRules()
		{
		}

		public virtual void StartDateRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>f4a39cb438de6052a86eedc445ec4e7d</Hash>
</Codenesium>*/