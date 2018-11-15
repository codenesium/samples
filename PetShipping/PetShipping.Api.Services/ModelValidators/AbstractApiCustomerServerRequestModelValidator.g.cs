using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiCustomerServerRequestModelValidator : AbstractValidator<ApiCustomerServerRequestModel>
	{
		private int existingRecordId;

		private ICustomerRepository customerRepository;

		public AbstractApiCustomerServerRequestModelValidator(ICustomerRepository customerRepository)
		{
			this.customerRepository = customerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCustomerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).NotNull();
			this.RuleFor(x => x.Email).Length(0, 128);
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull();
			this.RuleFor(x => x.FirstName).Length(0, 128);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull();
			this.RuleFor(x => x.LastName).Length(0, 128);
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).Length(0, 2147483647);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).NotNull();
			this.RuleFor(x => x.Phone).Length(0, 10);
		}
	}
}

/*<Codenesium>
    <Hash>ac936224ddc01d1b18478dd27f72bdb3</Hash>
</Codenesium>*/