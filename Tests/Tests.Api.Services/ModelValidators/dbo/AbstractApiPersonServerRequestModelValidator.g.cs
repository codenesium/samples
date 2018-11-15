using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiPersonServerRequestModelValidator : AbstractValidator<ApiPersonServerRequestModel>
	{
		private int existingRecordId;

		private IPersonRepository personRepository;

		public AbstractApiPersonServerRequestModelValidator(IPersonRepository personRepository)
		{
			this.personRepository = personRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PersonNameRules()
		{
			this.RuleFor(x => x.PersonName).NotNull();
			this.RuleFor(x => x.PersonName).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>f4aa3bcfbc076fdfa29aa34a863173f4</Hash>
</Codenesium>*/