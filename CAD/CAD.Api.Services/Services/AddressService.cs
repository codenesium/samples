using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class AddressService : AbstractService, IAddressService
	{
		private MediatR.IMediator mediator;

		protected IAddressRepository AddressRepository { get; private set; }

		protected IApiAddressServerRequestModelValidator AddressModelValidator { get; private set; }

		protected IDALAddressMapper DalAddressMapper { get; private set; }

		protected IDALCallMapper DalCallMapper { get; private set; }

		private ILogger logger;

		public AddressService(
			ILogger<IAddressService> logger,
			MediatR.IMediator mediator,
			IAddressRepository addressRepository,
			IApiAddressServerRequestModelValidator addressModelValidator,
			IDALAddressMapper dalAddressMapper,
			IDALCallMapper dalCallMapper)
			: base()
		{
			this.AddressRepository = addressRepository;
			this.AddressModelValidator = addressModelValidator;
			this.DalAddressMapper = dalAddressMapper;
			this.DalCallMapper = dalCallMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiAddressServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Address> records = await this.AddressRepository.All(limit, offset, query);

			return this.DalAddressMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiAddressServerResponseModel> Get(int id)
		{
			Address record = await this.AddressRepository.Get(id);

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
			int id,
			ApiAddressServerRequestModel model)
		{
			var validationResult = await this.AddressModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Address record = this.DalAddressMapper.MapModelToEntity(id, model);
				await this.AddressRepository.Update(record);

				record = await this.AddressRepository.Get(id);

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
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.AddressModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.AddressRepository.Delete(id);

				await this.mediator.Publish(new AddressDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCallServerResponseModel>> CallsByAddressId(int addressId, int limit = int.MaxValue, int offset = 0)
		{
			List<Call> records = await this.AddressRepository.CallsByAddressId(addressId, limit, offset);

			return this.DalCallMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>4dcb05c0ac93186852b78a2e9d964a26</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/