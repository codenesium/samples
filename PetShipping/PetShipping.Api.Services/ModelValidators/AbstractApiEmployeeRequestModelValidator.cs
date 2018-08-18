using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiEmployeeRequestModelValidator : AbstractValidator<ApiEmployeeRequestModel>
	{
		private int existingRecordId;

		private IEmployeeRepository employeeRepository;

		public AbstractApiEmployeeRequestModelValidator(IEmployeeRepository employeeRepository)
		{
			this.employeeRepository = employeeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void FirstNameRules()
		{
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
			this.RuleFor(x => x.LastName).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>719723a5ebd155670a573a24bb7abdde</Hash>
</Codenesium>*/