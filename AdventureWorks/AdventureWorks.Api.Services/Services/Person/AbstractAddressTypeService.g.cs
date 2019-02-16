using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractAddressTypeService : AbstractService
	{
		private IMediator mediator;

		protected IAddressTypeRepository AddressTypeRepository { get; private set; }

		protected IApiAddressTypeServerRequestModelValidator AddressTypeModelValidator { get; private set; }

		protected IDALAddressTypeMapper DalAddressTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractAddressTypeService(
			ILogger logger,
			IMediator mediator,
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
			var records = await this.AddressTypeRepository.All(limit, offset, query);

			return this.DalAddressTypeMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiAddressTypeServerResponseModel> Get(int addressTypeID)
		{
			var record = await this.AddressTypeRepository.Get(addressTypeID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalAddressTypeMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiAddressTypeServerResponseModel>> Create(
			ApiAddressTypeServerRequestModel model)
		{
			CreateResponse<ApiAddressTypeServerResponseModel> response = ValidationResponseFactory<ApiAddressTypeServerResponseModel>.CreateResponse(await this.AddressTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalAddressTypeMapper.MapModelToBO(default(int), model);
				var record = await this.AddressTypeRepository.Create(bo);

				response.SetRecord(this.DalAddressTypeMapper.MapBOToModel(record));
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
				var bo = this.DalAddressTypeMapper.MapModelToBO(addressTypeID, model);
				await this.AddressTypeRepository.Update(bo);

				var record = await this.AddressTypeRepository.Get(addressTypeID);

				var apiModel = this.DalAddressTypeMapper.MapBOToModel(record);
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
				return this.DalAddressTypeMapper.MapBOToModel(record);
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
				return this.DalAddressTypeMapper.MapBOToModel(record);
			}
		}
	}
}

/*<Codenesium>
    <Hash>7ab3ae41fc0f27c1f8865ce10229d6c2</Hash>
</Codenesium>*/