using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiPenServerRequestModelValidator : AbstractValidator<ApiPenServerRequestModel>
	{
		private int existingRecordId;

		private IPenRepository penRepository;

		public AbstractApiPenServerRequestModelValidator(IPenRepository penRepository)
		{
			this.penRepository = penRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPenServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>687d2efc279b0cc52301208f11f194de</Hash>
</Codenesium>*/