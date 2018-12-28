using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPurchaseOrderHeaderService : AbstractService
	{
		private IMediator mediator;

		protected IPurchaseOrderHeaderRepository PurchaseOrderHeaderRepository { get; private set; }

		protected IApiPurchaseOrderHeaderServerRequestModelValidator PurchaseOrderHeaderModelValidator { get; private set; }

		protected IBOLPurchaseOrderHeaderMapper BolPurchaseOrderHeaderMapper { get; private set; }

		protected IDALPurchaseOrderHeaderMapper DalPurchaseOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractPurchaseOrderHeaderService(
			ILogger logger,
			IMediator mediator,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IApiPurchaseOrderHeaderServerRequestModelValidator purchaseOrderHeaderModelValidator,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base()
		{
			this.PurchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
			this.PurchaseOrderHeaderModelValidator = purchaseOrderHeaderModelValidator;
			this.BolPurchaseOrderHeaderMapper = bolPurchaseOrderHeaderMapper;
			this.DalPurchaseOrderHeaderMapper = dalPurchaseOrderHeaderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PurchaseOrderHeaderRepository.All(limit, offset);

			return this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPurchaseOrderHeaderServerResponseModel> Get(int purchaseOrderID)
		{
			var record = await this.PurchaseOrderHeaderRepository.Get(purchaseOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPurchaseOrderHeaderServerResponseModel>> Create(
			ApiPurchaseOrderHeaderServerRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderHeaderServerResponseModel> response = ValidationResponseFactory<ApiPurchaseOrderHeaderServerResponseModel>.CreateResponse(await this.PurchaseOrderHeaderModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPurchaseOrderHeaderMapper.MapModelToBO(default(int), model);
				var record = await this.PurchaseOrderHeaderRepository.Create(this.DalPurchaseOrderHeaderMapper.MapBOToEF(bo));

				var businessObject = this.DalPurchaseOrderHeaderMapper.MapEFToBO(record);
				response.SetRecord(this.BolPurchaseOrderHeaderMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new PurchaseOrderHeaderCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPurchaseOrderHeaderServerResponseModel>> Update(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderServerRequestModel model)
		{
			var validationResult = await this.PurchaseOrderHeaderModelValidator.ValidateUpdateAsync(purchaseOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPurchaseOrderHeaderMapper.MapModelToBO(purchaseOrderID, model);
				await this.PurchaseOrderHeaderRepository.Update(this.DalPurchaseOrderHeaderMapper.MapBOToEF(bo));

				var record = await this.PurchaseOrderHeaderRepository.Get(purchaseOrderID);

				var businessObject = this.DalPurchaseOrderHeaderMapper.MapEFToBO(record);
				var apiModel = this.BolPurchaseOrderHeaderMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new PurchaseOrderHeaderUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPurchaseOrderHeaderServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPurchaseOrderHeaderServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int purchaseOrderID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PurchaseOrderHeaderModelValidator.ValidateDeleteAsync(purchaseOrderID));

			if (response.Success)
			{
				await this.PurchaseOrderHeaderRepository.Delete(purchaseOrderID);

				await this.mediator.Publish(new PurchaseOrderHeaderDeletedNotification(purchaseOrderID));
			}

			return response;
		}

		public async virtual Task<List<ApiPurchaseOrderHeaderServerResponseModel>> ByEmployeeID(int employeeID, int limit = 0, int offset = int.MaxValue)
		{
			List<PurchaseOrderHeader> records = await this.PurchaseOrderHeaderRepository.ByEmployeeID(employeeID, limit, offset);

			return this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPurchaseOrderHeaderServerResponseModel>> ByVendorID(int vendorID, int limit = 0, int offset = int.MaxValue)
		{
			List<PurchaseOrderHeader> records = await this.PurchaseOrderHeaderRepository.ByVendorID(vendorID, limit, offset);

			return this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>622e29ceba37c2f04cba9990d2548749</Hash>
</Codenesium>*/