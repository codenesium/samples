using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductProductPhotoServerRequestModelValidator : AbstractValidator<ApiProductProductPhotoServerRequestModel>
	{
		private int existingRecordId;

		protected IProductProductPhotoRepository ProductProductPhotoRepository { get; private set; }

		public AbstractApiProductProductPhotoServerRequestModelValidator(IProductProductPhotoRepository productProductPhotoRepository)
		{
			this.ProductProductPhotoRepository = productProductPhotoRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductProductPhotoServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void PrimaryRules()
		{
		}

		public virtual void ProductPhotoIDRules()
		{
			this.RuleFor(x => x.ProductPhotoID).MustAsync(this.BeValidProductPhotoByProductPhotoID).When(x => !x?.ProductPhotoID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidProductByProductID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ProductProductPhotoRepository.ProductByProductID(id);

			return record != null;
		}

		protected async Task<bool> BeValidProductPhotoByProductPhotoID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ProductProductPhotoRepository.ProductPhotoByProductPhotoID(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>bfc594639a2d130b9ba71fd4aeed4805</Hash>
</Codenesium>*/