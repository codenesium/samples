using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractAddressService : AbstractService
	{
		protected IAddressRepository AddressRepository { get; private set; }

		protected IApiAddressServerRequestModelValidator AddressModelValidator { get; private set; }

		protected IBOLAddressMapper BolAddressMapper { get; private set; }

		protected IDALAddressMapper DalAddressMapper { get; private set; }

		private ILogger logger;

		public AbstractAddressService(
			ILogger logger,
			IAddressRepository addressRepository,
			IApiAddressServerRequestModelValidator addressModelValidator,
			IBOLAddressMapper bolAddressMapper,
			IDALAddressMapper dalAddressMapper)
			: base()
		{
			this.AddressRepository = addressRepository;
			this.AddressModelValidator = addressModelValidator;
			this.BolAddressMapper = bolAddressMapper;
			this.DalAddressMapper = dalAddressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAddressServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.AddressRepository.All(limit, offset);

			return this.BolAddressMapper.MapBOToModel(this.DalAddressMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAddressServerResponseModel> Get(int addressID)
		{
			var record = await this.AddressRepository.Get(addressID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAddressMapper.MapBOToModel(this.DalAddressMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAddressServerResponseModel>> Create(
			ApiAddressServerRequestModel model)
		{
			CreateResponse<ApiAddressServerResponseModel> response = ValidationResponseFactory<ApiAddressServerResponseModel>.CreateResponse(await this.AddressModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolAddressMapper.MapModelToBO(default(int), model);
				var record = await this.AddressRepository.Create(this.DalAddressMapper.MapBOToEF(bo));

				response.SetRecord(this.BolAddressMapper.MapBOToModel(this.DalAddressMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAddressServerResponseModel>> Update(
			int addressID,
			ApiAddressServerRequestModel model)
		{
			var validationResult = await this.AddressModelValidator.ValidateUpdateAsync(addressID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolAddressMapper.MapModelToBO(addressID, model);
				await this.AddressRepository.Update(this.DalAddressMapper.MapBOToEF(bo));

				var record = await this.AddressRepository.Get(addressID);

				return ValidationResponseFactory<ApiAddressServerResponseModel>.UpdateResponse(this.BolAddressMapper.MapBOToModel(this.DalAddressMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiAddressServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int addressID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.AddressModelValidator.ValidateDeleteAsync(addressID));

			if (response.Success)
			{
				await this.AddressRepository.Delete(addressID);
			}

			return response;
		}

		public async virtual Task<ApiAddressServerResponseModel> ByRowguid(Guid rowguid)
		{
			Address record = await this.AddressRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAddressMapper.MapBOToModel(this.DalAddressMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<ApiAddressServerResponseModel> ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode)
		{
			Address record = await this.AddressRepository.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(addressLine1, addressLine2, city, stateProvinceID, postalCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAddressMapper.MapBOToModel(this.DalAddressMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiAddressServerResponseModel>> ByStateProvinceID(int stateProvinceID, int limit = 0, int offset = int.MaxValue)
		{
			List<Address> records = await this.AddressRepository.ByStateProvinceID(stateProvinceID, limit, offset);

			return this.BolAddressMapper.MapBOToModel(this.DalAddressMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>c5550d2ab1820546c652482138557d2f</Hash>
</Codenesium>*/