using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiOrganizationRequestModelValidator : AbstractValidator<ApiOrganizationRequestModel>
	{
		private int existingRecordId;

		private IOrganizationRepository organizationRepository;

		public AbstractApiOrganizationRequestModelValidator(IOrganizationRepository organizationRepository)
		{
			this.organizationRepository = organizationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiOrganizationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>9b5b5dd9170dda8ad91ce88887d5eb03</Hash>
</Codenesium>*/