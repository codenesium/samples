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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractAddressService: AbstractService
	{
		private IAddressRepository addressRepository;
		private IApiAddressRequestModelValidator addressModelValidator;
		private IBOLAddressMapper bolAddressMapper;
		private IDALAddressMapper dalAddressMapper;
		private ILogger logger;

		public AbstractAddressService(
			ILogger logger,
			IAddressRepository addressRepository,
			IApiAddressRequestModelValidator addressModelValidator,
			IBOLAddressMapper boladdressMapper,
			IDALAddressMapper daladdressMapper)
			: base()

		{
			this.addressRepository = addressRepository;
			this.addressModelValidator = addressModelValidator;
			this.bolAddressMapper = boladdressMapper;
			this.dalAddressMapper = daladdressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAddressResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.addressRepository.All(skip, take, orderClause);

			return this.bolAddressMapper.MapBOToModel(this.dalAddressMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAddressResponseModel> Get(int addressID)
		{
			var record = await addressRepository.Get(addressID);

			return this.bolAddressMapper.MapBOToModel(this.dalAddressMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiAddressResponseModel>> Create(
			ApiAddressRequestModel model)
		{
			CreateResponse<ApiAddressResponseModel> response = new CreateResponse<ApiAddressResponseModel>(await this.addressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolAddressMapper.MapModelToBO(default (int), model);
				var record = await this.addressRepository.Create(this.dalAddressMapper.MapBOToEF(bo));

				response.SetRecord(this.bolAddressMapper.MapBOToModel(this.dalAddressMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int addressID,
			ApiAddressRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.addressModelValidator.ValidateUpdateAsync(addressID, model));

			if (response.Success)
			{
				var bo = this.bolAddressMapper.MapModelToBO(addressID, model);
				await this.addressRepository.Update(this.dalAddressMapper.MapBOToEF(bo));
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

		public async Task<ApiAddressResponseModel> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode)
		{
			Address record = await this.addressRepository.GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(addressLine1,addressLine2,city,stateProvinceID,postalCode);

			return this.bolAddressMapper.MapBOToModel(this.dalAddressMapper.MapEFToBO(record));
		}
		public async Task<List<ApiAddressResponseModel>> GetStateProvinceID(int stateProvinceID)
		{
			List<Address> records = await this.addressRepository.GetStateProvinceID(stateProvinceID);

			return this.bolAddressMapper.MapBOToModel(this.dalAddressMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>232e2ec21a545b5398bd5c645e587d7f</Hash>
</Codenesium>*/