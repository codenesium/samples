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
	public abstract class AbstractBOAddress: AbstractBOManager
	{
		private IAddressRepository addressRepository;
		private IApiAddressModelValidator addressModelValidator;
		private ILogger logger;

		public AbstractBOAddress(
			ILogger logger,
			IAddressRepository addressRepository,
			IApiAddressModelValidator addressModelValidator)
			: base()

		{
			this.addressRepository = addressRepository;
			this.addressModelValidator = addressModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.addressRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOAddress> Get(int addressID)
		{
			return this.addressRepository.Get(addressID);
		}

		public virtual async Task<CreateResponse<POCOAddress>> Create(
			ApiAddressModel model)
		{
			CreateResponse<POCOAddress> response = new CreateResponse<POCOAddress>(await this.addressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOAddress record = await this.addressRepository.Create(model);

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
				await this.addressRepository.Update(addressID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int addressID)
		{
			ActionResponse response = new ActionResponse(await this.addressModelValidator.ValidateDeleteAsync(addressID));

			if (response.Success)
			{
				await this.addressRepository.Delete(addressID);
			}
			return response;
		}

		public async Task<POCOAddress> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode)
		{
			return await this.addressRepository.GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(addressLine1,addressLine2,city,stateProvinceID,postalCode);
		}
		public async Task<List<POCOAddress>> GetStateProvinceID(int stateProvinceID)
		{
			return await this.addressRepository.GetStateProvinceID(stateProvinceID);
		}
	}
}

/*<Codenesium>
    <Hash>efc30171afb60fcd211d9f5bf436befe</Hash>
</Codenesium>*/