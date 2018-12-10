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
	public abstract class AbstractApiCustomerCommunicationServerRequestModelValidator : AbstractValidator<ApiCustomerCommunicationServerRequestModel>
	{
		private int existingRecordId;

		protected ICustomerCommunicationRepository CustomerCommunicationRepository { get; private set; }

		public AbstractApiCustomerCommunicationServerRequestModelValidator(ICustomerCommunicationRepository customerCommunicationRepository)
		{
			this.CustomerCommunicationRepository = customerCommunicationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCustomerCommunicationServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CustomerIdRules()
		{
			this.RuleFor(x => x.CustomerId).MustAsync(this.BeValidCustomerByCustomerId).When(x => !x?.CustomerId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void DateCreatedRules()
		{
		}

		public virtual void EmployeeIdRules()
		{
			this.RuleFor(x => x.EmployeeId).MustAsync(this.BeValidEmployeeByEmployeeId).When(x => !x?.EmployeeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Note).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidCustomerByCustomerId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CustomerCommunicationRepository.CustomerByCustomerId(id);

			return record != null;
		}

		protected async Task<bool> BeValidEmployeeByEmployeeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CustomerCommunicationRepository.EmployeeByEmployeeId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>a26498708052c6c9c83b5c85a5488cc4</Hash>
</Codenesium>*/