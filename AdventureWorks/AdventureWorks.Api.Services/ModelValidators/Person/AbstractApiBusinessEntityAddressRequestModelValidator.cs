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
	public abstract class AbstractApiBusinessEntityAddressRequestModelValidator : AbstractValidator<ApiBusinessEntityAddressRequestModel>
	{
		private int existingRecordId;

		private IBusinessEntityAddressRepository businessEntityAddressRepository;

		public AbstractApiBusinessEntityAddressRequestModelValidator(IBusinessEntityAddressRepository businessEntityAddressRepository)
		{
			this.businessEntityAddressRepository = businessEntityAddressRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityAddressRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AddressIDRules()
		{
		}

		public virtual void AddressTypeIDRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void RowguidRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>ecae3a0779c0fc5508153105fa583478</Hash>
</Codenesium>*/