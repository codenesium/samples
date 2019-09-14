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
	public class ApiSaleServerRequestModelValidator : AbstractValidator<ApiSaleServerRequestModel>, IApiSaleServerRequestModelValidator
	{
		private int existingRecordId;

		protected ISaleRepository SaleRepository { get; private set; }

		public ApiSaleServerRequestModelValidator(ISaleRepository saleRepository)
		{
			this.SaleRepository = saleRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleServerRequestModel model)
		{
			this.AmountRules();
			this.CutomerIdRules();
			this.NoteRules();
			this.PetIdRules();
			this.SaleDateRules();
			this.SalesPersonIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleServerRequestModel model)
		{
			this.AmountRules();
			this.CutomerIdRules();
			this.NoteRules();
			this.PetIdRules();
			this.SaleDateRules();
			this.SalesPersonIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void AmountRules()
		{
		}

		public virtual void CutomerIdRules()
		{
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Note).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PetIdRules()
		{
			this.RuleFor(x => x.PetId).MustAsync(this.BeValidPetByPetId).When(x => !x?.PetId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void SaleDateRules()
		{
		}

		public virtual void SalesPersonIdRules()
		{
		}

		protected async Task<bool> BeValidPetByPetId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SaleRepository.PetByPetId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>ec42653d6937f78da31cc3e3211da698</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/