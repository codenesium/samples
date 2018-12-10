using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiCompositePrimaryKeyServerRequestModelValidator : AbstractValidator<ApiCompositePrimaryKeyServerRequestModel>
	{
		private int existingRecordId;

		protected ICompositePrimaryKeyRepository CompositePrimaryKeyRepository { get; private set; }

		public AbstractApiCompositePrimaryKeyServerRequestModelValidator(ICompositePrimaryKeyRepository compositePrimaryKeyRepository)
		{
			this.CompositePrimaryKeyRepository = compositePrimaryKeyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCompositePrimaryKeyServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void Id2Rules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>2438522c3b929ec531e5a3c82da2c05b</Hash>
</Codenesium>*/