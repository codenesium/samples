using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiCustomerCommunicationServerRequestModelValidator : AbstractValidator<ApiCustomerCommunicationServerRequestModel>
	{
		private int existingRecordId;

		private ICustomerCommunicationRepository customerCommunicationRepository;

		public AbstractApiCustomerCommunicationServerRequestModelValidator(ICustomerCommunicationRepository customerCommunicationRepository)
		{
			this.customerCommunicationRepository = customerCommunicationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCustomerCommunicationServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CustomerIdRules()
		{
			this.RuleFor(x => x.CustomerId).MustAsync(this.BeValidCustomerByCustomerId).When(x => !x?.CustomerId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void DateCreatedRules()
		{
		}

		public virtual void EmployeeIdRules()
		{
			this.RuleFor(x => x.EmployeeId).MustAsync(this.BeValidEmployeeByEmployeeId).When(x => !x?.EmployeeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull();
			this.RuleFor(x => x.Note).Length(0, 2147483647);
		}

		private async Task<bool> BeValidCustomerByCustomerId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.customerCommunicationRepository.CustomerByCustomerId(id);

			return record != null;
		}

		private async Task<bool> BeValidEmployeeByEmployeeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.customerCommunicationRepository.EmployeeByEmployeeId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>fc16e7d3121ae72932fb84900f2cc861</Hash>
</Codenesium>*/