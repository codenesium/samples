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
			this.RuleFor(x => x.ClientId).MustAsync(this.BeValidClient).When(x => x?.ClientId != null).WithMessage("Invalid reference");
		}

		public virtual void DateCreatedRules()
		{
		}

		public virtual void EmployeeIdRules()
		{
			this.RuleFor(x => x.EmployeeId).MustAsync(this.BeValidEmployee).When(x => x?.EmployeeId != null).WithMessage("Invalid reference");
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull();
			this.RuleFor(x => x.Note).Length(0, 2147483647);
		}

		private async Task<bool> BeValidClient(int id,  CancellationToken cancellationToken)
		{
			var record = await this.clientCommunicationRepository.GetClient(id);

			return record != null;
		}

		private async Task<bool> BeValidEmployee(int id,  CancellationToken cancellationToken)
		{
			var record = await this.clientCommunicationRepository.GetEmployee(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>145b63506b78a56fdecef3ee3a4576fb</Hash>
</Codenesium>*/