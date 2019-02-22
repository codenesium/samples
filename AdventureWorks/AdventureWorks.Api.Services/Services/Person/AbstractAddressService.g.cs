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
		private MediatR.IMediator mediator;

		protected IAddressRepository AddressRepository { get; private set; }

		protected IApiAddressServerRequestModelValidator AddressModelValidator { get; private set; }

		protected IDALAddressMapper DalAddressMapper { get; private set; }

		private ILogger logger;

		public AbstractAddressService(
			ILogger logger,
			MediatR.IMediator mediator,
			IAddressRepository addressRepository,
			IApiAddressServerRequestModelValidator addressModelValidator,
			IDALAddressMapper dalAddressMapper)
			: base()
		{
			this.AddressRepository = addressRepository;
			this.AddressModelValidator = addressModelValidator;
			this.DalAddressMapper = dalAddressMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiAddressServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Address> records = await this.AddressRepository.All(limit, offset, query);

			return this.DalAddressMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiAddressServerResponseModel> Get(int addressID)
		{
			Address record = await this.AddressRepository.Get(addressID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalAddressMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiAddressServerResponseModel>> Create(
			ApiAddressServerRequestModel model)
		{
			CreateResponse<ApiAddressServerResponseModel> response = ValidationResponseFactory<ApiAddressServerResponseModel>.CreateResponse(await this.AddressModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Address record = this.DalAddressMapper.MapModelToEntity(default(int), model);
				record = await this.AddressRepository.Create(record);

				response.SetRecord(this.DalAddressMapper.MapEntityToModel(record));
				await this.mediator.Publish(new AddressCreatedNotification(response.Record));
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
				Address record = this.DalAddressMapper.MapModelToEntity(addressID, model);
				await this.AddressRepository.Update(record);

				record = await this.AddressRepository.Get(addressID);

				ApiAddressServerResponseModel apiModel = this.DalAddressMapper.MapEntityToModel(record);
				await this.mediator.Publish(new AddressUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiAddressServerResponseModel>.UpdateResponse(apiModel);
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

				await this.mediator.Publish(new AddressDeletedNotification(addressID));
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
				return this.DalAddressMapper.MapEntityToModel(record);
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
				return this.DalAddressMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiAddressServerResponseModel>> ByStateProvinceID(int stateProvinceID, int limit = 0, int offset = int.MaxValue)
		{
			List<Address> records = await this.AddressRepository.ByStateProvinceID(stateProvinceID, limit, offset);

			return this.DalAddressMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>16bb52e421f9fd5b80dd0ec1c08b3d0d</Hash>
</Codenesium>*/