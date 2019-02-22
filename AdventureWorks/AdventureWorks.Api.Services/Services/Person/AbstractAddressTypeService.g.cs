using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractAddressTypeService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IAddressTypeRepository AddressTypeRepository { get; private set; }

		protected IApiAddressTypeServerRequestModelValidator AddressTypeModelValidator { get; private set; }

		protected IDALAddressTypeMapper DalAddressTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractAddressTypeService(
			ILogger logger,
			MediatR.IMediator mediator,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeServerRequestModelValidator addressTypeModelValidator,
			IDALAddressTypeMapper dalAddressTypeMapper)
			: base()
		{
			this.AddressTypeRepository = addressTypeRepository;
			this.AddressTypeModelValidator = addressTypeModelValidator;
			this.DalAddressTypeMapper = dalAddressTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiAddressTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<AddressType> records = await this.AddressTypeRepository.All(limit, offset, query);

			return this.DalAddressTypeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiAddressTypeServerResponseModel> Get(int addressTypeID)
		{
			AddressType record = await this.AddressTypeRepository.Get(addressTypeID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalAddressTypeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiAddressTypeServerResponseModel>> Create(
			ApiAddressTypeServerRequestModel model)
		{
			CreateResponse<ApiAddressTypeServerResponseModel> response = ValidationResponseFactory<ApiAddressTypeServerResponseModel>.CreateResponse(await this.AddressTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				AddressType record = this.DalAddressTypeMapper.MapModelToEntity(default(int), model);
				record = await this.AddressTypeRepository.Create(record);

				response.SetRecord(this.DalAddressTypeMapper.MapEntityToModel(record));
				await this.mediator.Publish(new AddressTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAddressTypeServerResponseModel>> Update(
			int addressTypeID,
			ApiAddressTypeServerRequestModel model)
		{
			var validationResult = await this.AddressTypeModelValidator.ValidateUpdateAsync(addressTypeID, model);

			if (validationResult.IsValid)
			{
				AddressType record = this.DalAddressTypeMapper.MapModelToEntity(addressTypeID, model);
				await this.AddressTypeRepository.Update(record);

				record = await this.AddressTypeRepository.Get(addressTypeID);

				ApiAddressTypeServerResponseModel apiModel = this.DalAddressTypeMapper.MapEntityToModel(record);
				await this.mediator.Publish(new AddressTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiAddressTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiAddressTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int addressTypeID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.AddressTypeModelValidator.ValidateDeleteAsync(addressTypeID));

			if (response.Success)
			{
				await this.AddressTypeRepository.Delete(addressTypeID);

				await this.mediator.Publish(new AddressTypeDeletedNotification(addressTypeID));
			}

			return response;
		}

		public async virtual Task<ApiAddressTypeServerResponseModel> ByName(string name)
		{
			AddressType record = await this.AddressTypeRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalAddressTypeMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<ApiAddressTypeServerResponseModel> ByRowguid(Guid rowguid)
		{
			AddressType record = await this.AddressTypeRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalAddressTypeMapper.MapEntityToModel(record);
			}
		}
	}
}

/*<Codenesium>
    <Hash>760aa6d5e46b60234ef8934d4c2ef625</Hash>
</Codenesium>*/