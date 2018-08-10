using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractAddressService : AbstractService
	{
		protected IAddressRepository AddressRepository { get; private set; }

		protected IApiAddressRequestModelValidator AddressModelValidator { get; private set; }

		protected IBOLAddressMapper BolAddressMapper { get; private set; }

		protected IDALAddressMapper DalAddressMapper { get; private set; }

		protected IBOLBusinessEntityAddressMapper BolBusinessEntityAddressMapper { get; private set; }

		protected IDALBusinessEntityAddressMapper DalBusinessEntityAddressMapper { get; private set; }

		private ILogger logger;

		public AbstractAddressService(
			ILogger logger,
			IAddressRepository addressRepository,
			IApiAddressRequestModelValidator addressModelValidator,
			IBOLAddressMapper bolAddressMapper,
			IDALAddressMapper dalAddressMapper,
			IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
			IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper)
			: base()
		{
			this.AddressRepository = addressRepository;
			this.AddressModelValidator = addressModelValidator;
			this.BolAddressMapper = bolAddressMapper;
			this.DalAddressMapper = dalAddressMapper;
			this.BolBusinessEntityAddressMapper = bolBusinessEntityAddressMapper;
			this.DalBusinessEntityAddressMapper = dalBusinessEntityAddressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAddressResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.AddressRepository.All(limit, offset);

			return this.BolAddressMapper.MapBOToModel(this.DalAddressMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAddressResponseModel> Get(int addressID)
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

		public virtual async Task<CreateResponse<ApiAddressResponseModel>> Create(
			ApiAddressRequestModel model)
		{
			CreateResponse<ApiAddressResponseModel> response = new CreateResponse<ApiAddressResponseModel>(await this.AddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolAddressMapper.MapModelToBO(default(int), model);
				var record = await this.AddressRepository.Create(this.DalAddressMapper.MapBOToEF(bo));

				response.SetRecord(this.BolAddressMapper.MapBOToModel(this.DalAddressMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAddressResponseModel>> Update(
			int addressID,
			ApiAddressRequestModel model)
		{
			var validationResult = await this.AddressModelValidator.ValidateUpdateAsync(addressID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolAddressMapper.MapModelToBO(addressID, model);
				await this.AddressRepository.Update(this.DalAddressMapper.MapBOToEF(bo));

				var record = await this.AddressRepository.Get(addressID);

				return new UpdateResponse<ApiAddressResponseModel>(this.BolAddressMapper.MapBOToModel(this.DalAddressMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiAddressResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int addressID)
		{
			ActionResponse response = new ActionResponse(await this.AddressModelValidator.ValidateDeleteAsync(addressID));
			if (response.Success)
			{
				await this.AddressRepository.Delete(addressID);
			}

			return response;
		}

		public async Task<ApiAddressResponseModel> ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode)
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

		public async Task<List<ApiAddressResponseModel>> ByStateProvinceID(int stateProvinceID)
		{
			List<Address> records = await this.AddressRepository.ByStateProvinceID(stateProvinceID);

			return this.BolAddressMapper.MapBOToModel(this.DalAddressMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int addressID, int limit = int.MaxValue, int offset = 0)
		{
			List<BusinessEntityAddress> records = await this.AddressRepository.BusinessEntityAddresses(addressID, limit, offset);

			return this.BolBusinessEntityAddressMapper.MapBOToModel(this.DalBusinessEntityAddressMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>aba8c6c12ef95e9f3a51527ca660fd60</Hash>
</Codenesium>*/