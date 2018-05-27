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
		private IApiAddressRequestModelValidator addressModelValidator;
		private IBOLAddressMapper addressMapper;
		private ILogger logger;

		public AbstractBOAddress(
			ILogger logger,
			IAddressRepository addressRepository,
			IApiAddressRequestModelValidator addressModelValidator,
			IBOLAddressMapper addressMapper)
			: base()

		{
			this.addressRepository = addressRepository;
			this.addressModelValidator = addressModelValidator;
			this.addressMapper = addressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAddressResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.addressRepository.All(skip, take, orderClause);

			return this.addressMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiAddressResponseModel> Get(int addressID)
		{
			var record = await addressRepository.Get(addressID);

			return this.addressMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiAddressResponseModel>> Create(
			ApiAddressRequestModel model)
		{
			CreateResponse<ApiAddressResponseModel> response = new CreateResponse<ApiAddressResponseModel>(await this.addressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.addressMapper.MapModelToDTO(default (int), model);
				var record = await this.addressRepository.Create(dto);

				response.SetRecord(this.addressMapper.MapDTOToModel(record));
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
				var dto = this.addressMapper.MapModelToDTO(addressID, model);
				await this.addressRepository.Update(addressID, dto);
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
			DTOAddress record = await this.addressRepository.GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(addressLine1,addressLine2,city,stateProvinceID,postalCode);

			return this.addressMapper.MapDTOToModel(record);
		}
		public async Task<List<ApiAddressResponseModel>> GetStateProvinceID(int stateProvinceID)
		{
			List<DTOAddress> records = await this.addressRepository.GetStateProvinceID(stateProvinceID);

			return this.addressMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>e1ebdeb76e2b64185faebe435a7358bf</Hash>
</Codenesium>*/