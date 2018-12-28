using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractShipMethodService : AbstractService
	{
		private IMediator mediator;

		protected IShipMethodRepository ShipMethodRepository { get; private set; }

		protected IApiShipMethodServerRequestModelValidator ShipMethodModelValidator { get; private set; }

		protected IBOLShipMethodMapper BolShipMethodMapper { get; private set; }

		protected IDALShipMethodMapper DalShipMethodMapper { get; private set; }

		protected IBOLPurchaseOrderHeaderMapper BolPurchaseOrderHeaderMapper { get; private set; }

		protected IDALPurchaseOrderHeaderMapper DalPurchaseOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractShipMethodService(
			ILogger logger,
			IMediator mediator,
			IShipMethodRepository shipMethodRepository,
			IApiShipMethodServerRequestModelValidator shipMethodModelValidator,
			IBOLShipMethodMapper bolShipMethodMapper,
			IDALShipMethodMapper dalShipMethodMapper,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base()
		{
			this.ShipMethodRepository = shipMethodRepository;
			this.ShipMethodModelValidator = shipMethodModelValidator;
			this.BolShipMethodMapper = bolShipMethodMapper;
			this.DalShipMethodMapper = dalShipMethodMapper;
			this.BolPurchaseOrderHeaderMapper = bolPurchaseOrderHeaderMapper;
			this.DalPurchaseOrderHeaderMapper = dalPurchaseOrderHeaderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiShipMethodServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ShipMethodRepository.All(limit, offset);

			return this.BolShipMethodMapper.MapBOToModel(this.DalShipMethodMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiShipMethodServerResponseModel> Get(int shipMethodID)
		{
			var record = await this.ShipMethodRepository.Get(shipMethodID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolShipMethodMapper.MapBOToModel(this.DalShipMethodMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiShipMethodServerResponseModel>> Create(
			ApiShipMethodServerRequestModel model)
		{
			CreateResponse<ApiShipMethodServerResponseModel> response = ValidationResponseFactory<ApiShipMethodServerResponseModel>.CreateResponse(await this.ShipMethodModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolShipMethodMapper.MapModelToBO(default(int), model);
				var record = await this.ShipMethodRepository.Create(this.DalShipMethodMapper.MapBOToEF(bo));

				var businessObject = this.DalShipMethodMapper.MapEFToBO(record);
				response.SetRecord(this.BolShipMethodMapper.MapBOToModel(businessObject));
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
				var bo = this.BolShipMethodMapper.MapModelToBO(shipMethodID, model);
				await this.ShipMethodRepository.Update(this.DalShipMethodMapper.MapBOToEF(bo));

				var record = await this.ShipMethodRepository.Get(shipMethodID);

				var businessObject = this.DalShipMethodMapper.MapEFToBO(record);
				var apiModel = this.BolShipMethodMapper.MapBOToModel(businessObject);
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
				return this.BolShipMethodMapper.MapBOToModel(this.DalShipMethodMapper.MapEFToBO(record));
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
				return this.BolShipMethodMapper.MapBOToModel(this.DalShipMethodMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiPurchaseOrderHeaderServerResponseModel>> PurchaseOrderHeadersByShipMethodID(int shipMethodID, int limit = int.MaxValue, int offset = 0)
		{
			List<PurchaseOrderHeader> records = await this.ShipMethodRepository.PurchaseOrderHeadersByShipMethodID(shipMethodID, limit, offset);

			return this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>aa2aa19c22a3869d8efdd6d8b41037d5</Hash>
</Codenesium>*/