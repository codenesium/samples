using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractShipMethodService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IShipMethodRepository ShipMethodRepository { get; private set; }

		protected IApiShipMethodServerRequestModelValidator ShipMethodModelValidator { get; private set; }

		protected IDALShipMethodMapper DalShipMethodMapper { get; private set; }

		protected IDALPurchaseOrderHeaderMapper DalPurchaseOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractShipMethodService(
			ILogger logger,
			MediatR.IMediator mediator,
			IShipMethodRepository shipMethodRepository,
			IApiShipMethodServerRequestModelValidator shipMethodModelValidator,
			IDALShipMethodMapper dalShipMethodMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base()
		{
			this.ShipMethodRepository = shipMethodRepository;
			this.ShipMethodModelValidator = shipMethodModelValidator;
			this.DalShipMethodMapper = dalShipMethodMapper;
			this.DalPurchaseOrderHeaderMapper = dalPurchaseOrderHeaderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiShipMethodServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<ShipMethod> records = await this.ShipMethodRepository.All(limit, offset, query);

			return this.DalShipMethodMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiShipMethodServerResponseModel> Get(int shipMethodID)
		{
			ShipMethod record = await this.ShipMethodRepository.Get(shipMethodID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalShipMethodMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiShipMethodServerResponseModel>> Create(
			ApiShipMethodServerRequestModel model)
		{
			CreateResponse<ApiShipMethodServerResponseModel> response = ValidationResponseFactory<ApiShipMethodServerResponseModel>.CreateResponse(await this.ShipMethodModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				ShipMethod record = this.DalShipMethodMapper.MapModelToEntity(default(int), model);
				record = await this.ShipMethodRepository.Create(record);

				response.SetRecord(this.DalShipMethodMapper.MapEntityToModel(record));
				await this.mediator.Publish(new ShipMethodCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiShipMethodServerResponseModel>> Update(
			int shipMethodID,
			ApiShipMethodServerRequestModel model)
		{
			var validationResult = await this.ShipMethodModelValidator.ValidateUpdateAsync(shipMethodID, model);

			if (validationResult.IsValid)
			{
				ShipMethod record = this.DalShipMethodMapper.MapModelToEntity(shipMethodID, model);
				await this.ShipMethodRepository.Update(record);

				record = await this.ShipMethodRepository.Get(shipMethodID);

				ApiShipMethodServerResponseModel apiModel = this.DalShipMethodMapper.MapEntityToModel(record);
				await this.mediator.Publish(new ShipMethodUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiShipMethodServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiShipMethodServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int shipMethodID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ShipMethodModelValidator.ValidateDeleteAsync(shipMethodID));

			if (response.Success)
			{
				await this.ShipMethodRepository.Delete(shipMethodID);

				await this.mediator.Publish(new ShipMethodDeletedNotification(shipMethodID));
			}

			return response;
		}

		public async virtual Task<ApiShipMethodServerResponseModel> ByName(string name)
		{
			ShipMethod record = await this.ShipMethodRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalShipMethodMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<ApiShipMethodServerResponseModel> ByRowguid(Guid rowguid)
		{
			ShipMethod record = await this.ShipMethodRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalShipMethodMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiPurchaseOrderHeaderServerResponseModel>> PurchaseOrderHeadersByShipMethodID(int shipMethodID, int limit = int.MaxValue, int offset = 0)
		{
			List<PurchaseOrderHeader> records = await this.ShipMethodRepository.PurchaseOrderHeadersByShipMethodID(shipMethodID, limit, offset);

			return this.DalPurchaseOrderHeaderMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>7687caca65bf83bd0ad0b482a296a634</Hash>
</Codenesium>*/