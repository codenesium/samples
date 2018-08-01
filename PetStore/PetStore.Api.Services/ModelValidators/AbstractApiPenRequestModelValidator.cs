using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiPenRequestModelValidator : AbstractValidator<ApiPenRequestModel>
	{
		private int existingRecordId;

		private IPenRepository penRepository;

		public AbstractApiPenRequestModelValidator(IPenRepository penRepository)
		{
			this.penRepository = penRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPenRequestModel model, int id)
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
    <Hash>3f7ca49d609e7d19b7679c0e3d10a69d</Hash>
</Codenesium>*/