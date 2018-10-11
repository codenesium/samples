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
	public abstract class AbstractApiClientCommunicationRequestModelValidator : AbstractValidator<ApiClientCommunicationRequestModel>
	{
		private int existingRecordId;

		private IClientCommunicationRepository clientCommunicationRepository;

		public AbstractApiClientCommunicationRequestModelValidator(IClientCommunicationRepository clientCommunicationRepository)
		{
			this.clientCommunicationRepository = clientCommunicationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiClientCommunicationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ClientIdRules()
		{
			this.RuleFor(x => x.ClientId).MustAsync(this.BeValidClientByClientId).When(x => x?.ClientId != null).WithMessage("Invalid reference");
		}

		public virtual void DateCreatedRules()
		{
		}

		public virtual void EmployeeIdRules()
		{
			this.RuleFor(x => x.EmployeeId).MustAsync(this.BeValidEmployeeByEmployeeId).When(x => x?.EmployeeId != null).WithMessage("Invalid reference");
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull();
			this.RuleFor(x => x.Note).Length(0, 2147483647);
		}

		private async Task<bool> BeValidClientByClientId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.clientCommunicationRepository.ClientByClientId(id);

			return record != null;
		}

		private async Task<bool> BeValidEmployeeByEmployeeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.clientCommunicationRepository.EmployeeByEmployeeId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>c0fb472f20fc1638a9698aea3594606d</Hash>
</Codenesium>*/