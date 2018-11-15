using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiEmployeeServerRequestModelValidator : AbstractValidator<ApiEmployeeServerRequestModel>
	{
		private int existingRecordId;

		private IEmployeeRepository employeeRepository;

		public AbstractApiEmployeeServerRequestModelValidator(IEmployeeRepository employeeRepository)
		{
			this.employeeRepository = employeeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull();
			this.RuleFor(x => x.FirstName).Length(0, 128);
		}

		public virtual void IsSalesPersonRules()
		{
		}

		public virtual void IsShipperRules()
		{
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull();
			this.RuleFor(x => x.LastName).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>ac280cd9ed5ab84c3c7d275a830e4b51</Hash>
</Codenesium>*/