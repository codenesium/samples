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
	public abstract class AbstractApiSaleServerRequestModelValidator : AbstractValidator<ApiSaleServerRequestModel>
	{
		private int existingRecordId;

		protected ISaleRepository SaleRepository { get; private set; }

		public AbstractApiSaleServerRequestModelValidator(ISaleRepository saleRepository)
		{
			this.SaleRepository = saleRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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
    <Hash>089aea391f5fa55f8aaa3129b57a69a1</Hash>
</Codenesium>*/