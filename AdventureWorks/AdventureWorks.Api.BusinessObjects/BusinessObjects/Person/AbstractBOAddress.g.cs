using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOAddress
	{
		private IAddressRepository addressRepository;
		private IApiAddressModelValidator addressModelValidator;
		private ILogger logger;

		public AbstractBOAddress(
			ILogger logger,
			IAddressRepository addressRepository,
			IApiAddressModelValidator addressModelValidator)

		{
			this.addressRepository = addressRepository;
			this.addressModelValidator = addressModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.addressRepository.All(skip, take, orderClause);
		}

		public virtual POCOAddress Get(int addressID)
		{
			return this.addressRepository.Get(addressID);
		}

		public virtual async Task<CreateResponse<POCOAddress>> Create(
			ApiAddressModel model)
		{
			CreateResponse<POCOAddress> response = new CreateResponse<POCOAddress>(await this.addressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOAddress record = this.addressRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int addressID,
			ApiAddressModel model)
		{
			ActionResponse response = new ActionResponse(await this.addressModelValidator.ValidateUpdateAsync(addressID, model));

			if (response.Success)
			{
				this.addressRepository.Update(addressID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int addressID)
		{
			ActionResponse response = new ActionResponse(await this.addressModelValidator.ValidateDeleteAsync(addressID));

			if (response.Success)
			{
				this.addressRepository.Delete(addressID);
			}
			return response;
		}

		public POCOAddress GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode)
		{
			return this.addressRepository.GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(addressLine1,addressLine2,city,stateProvinceID,postalCode);
		}

		public List<POCOAddress> GetStateProvinceID(int stateProvinceID)
		{
			return this.addressRepository.GetStateProvinceID(stateProvinceID);
		}
	}
}

/*<Codenesium>
    <Hash>c298f86ded437dd9f2e2a1082ab92647</Hash>
</Codenesium>*/