using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractClientCommunicationModelValidator: AbstractValidator<ClientCommunicationModel>
	{
		public new ValidationResult Validate(ClientCommunicationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ClientCommunicationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IClientRepository ClientRepository { get; set; }
		public IEmployeeRepository EmployeeRepository { get; set; }
		public virtual void ClientIdRules()
		{
			this.RuleFor(x => x.ClientId).NotNull();
			this.RuleFor(x => x.ClientId).Must(this.BeValidClient).When(x => x ?.ClientId != null).WithMessage("Invalid reference");
		}

		public virtual void DateCreatedRules()
		{
			this.RuleFor(x => x.DateCreated).NotNull();
		}

		public virtual void EmployeeIdRules()
		{
			this.RuleFor(x => x.EmployeeId).NotNull();
			this.RuleFor(x => x.EmployeeId).Must(this.BeValidEmployee).When(x => x ?.EmployeeId != null).WithMessage("Invalid reference");
		}

		public virtual void NotesRules()
		{
			this.RuleFor(x => x.Notes).NotNull();
			this.RuleFor(x => x.Notes).Length(0, 2147483647);
		}

		private bool BeValidClient(int id)
		{
			return this.ClientRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidEmployee(int id)
		{
			return this.EmployeeRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>ca7c85b5e3e0472b69be3b3d6c9c0fb0</Hash>
</Codenesium>*/