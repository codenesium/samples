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
	public abstract class AbstractApiPersonRefServerRequestModelValidator : AbstractValidator<ApiPersonRefServerRequestModel>
	{
		private int existingRecordId;

		protected IPersonRefRepository PersonRefRepository { get; private set; }

		public AbstractApiPersonRefServerRequestModelValidator(IPersonRefRepository personRefRepository)
		{
			this.PersonRefRepository = personRefRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonRefServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PersonAIdRules()
		{
		}

		public virtual void PersonBIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>b1d9b36bcc7c4d0b094329cd7539fa93</Hash>
</Codenesium>*/