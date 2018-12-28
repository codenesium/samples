using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductService : AbstractService
	{
		private IMediator mediator;

		protected IProductRepository ProductRepository { get; private set; }

		protected IApiProductServerRequestModelValidator ProductModelValidator { get; private set; }

		protected IBOLProductMapper BolProductMapper { get; private set; }

		protected IDALProductMapper DalProductMapper { get; private set; }

		protected IBOLBillOfMaterialMapper BolBillOfMaterialMapper { get; private set; }

		protected IDALBillOfMaterialMapper DalBillOfMaterialMapper { get; private set; }

		protected IBOLProductReviewMapper BolProductReviewMapper { get; private set; }

		protected IDALProductReviewMapper DalProductReviewMapper { get; private set; }

		protected IBOLTransactionHistoryMapper BolTransactionHistoryMapper { get; private set; }

		protected IDALTransactionHistoryMapper DalTransactionHistoryMapper { get; private set; }

		protected IBOLWorkOrderMapper BolWorkOrderMapper { get; private set; }

		protected IDALWorkOrderMapper DalWorkOrderMapper { get; private set; }

		private ILogger logger;

		public AbstractProductService(
			ILogger logger,
			IMediator mediator,
			IProductRepository productRepository,
			IApiProductServerRequestModelValidator productModelValidator,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper,
			IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper,
			IBOLProductReviewMapper bolProductReviewMapper,
			IDALProductReviewMapper dalProductReviewMapper,
			IBOLTransactionHistoryMapper bolTransactionHistoryMapper,
			IDALTransactionHistoryMapper dalTransactionHistoryMapper,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base()
		{
			this.ProductRepository = productRepository;
			this.ProductModelValidator = productModelValidator;
			this.BolProductMapper = bolProductMapper;
			this.DalProductMapper = dalProductMapper;
			this.BolBillOfMaterialMapper = bolBillOfMaterialMapper;
			this.DalBillOfMaterialMapper = dalBillOfMaterialMapper;
			this.BolProductReviewMapper = bolProductReviewMapper;
			this.DalProductReviewMapper = dalProductReviewMapper;
			this.BolTransactionHistoryMapper = bolTransactionHistoryMapper;
			this.DalTransactionHistoryMapper = dalTransactionHistoryMapper;
			this.BolWorkOrderMapper = bolWorkOrderMapper;
			this.DalWorkOrderMapper = dalWorkOrderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProductServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductRepository.All(limit, offset);

			return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductServerResponseModel> Get(int productID)
		{
			var record = await this.ProductRepository.Get(productID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductServerResponseModel>> Create(
			ApiProductServerRequestModel model)
		{
			CreateResponse<ApiProductServerResponseModel> response = ValidationResponseFactory<ApiProductServerResponseModel>.CreateResponse(await this.ProductModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolProductMapper.MapModelToBO(default(int), model);
				var record = await this.ProductRepository.Create(this.DalProductMapper.MapBOToEF(bo));

				var businessObject = this.DalProductMapper.MapEFToBO(record);
				response.SetRecord(this.BolProductMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new ProductCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductServerResponseModel>> Update(
			int productID,
			ApiProductServerRequestModel model)
		{
			var validationResult = await this.ProductModelValidator.ValidateUpdateAsync(productID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductMapper.MapModelToBO(productID, model);
				await this.ProductRepository.Update(this.DalProductMapper.MapBOToEF(bo));

				var record = await this.ProductRepository.Get(productID);

				var businessObject = this.DalProductMapper.MapEFToBO(record);
				var apiModel = this.BolProductMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new ProductUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiProductServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiProductServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ProductModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.ProductRepository.Delete(productID);

				await this.mediator.Publish(new ProductDeletedNotification(productID));
			}

			return response;
		}

		public async virtual Task<ApiProductServerResponseModel> ByName(string name)
		{
			Product record = await this.ProductRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<ApiProductServerResponseModel> ByProductNumber(string productNumber)
		{
			Product record = await this.ProductRepository.ByProductNumber(productNumber);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<ApiProductServerResponseModel> ByRowguid(Guid rowguid)
		{
			Product record = await this.ProductRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiBillOfMaterialServerResponseModel>> BillOfMaterialsByProductAssemblyID(int productAssemblyID, int limit = int.MaxValue, int offset = 0)
		{
			List<BillOfMaterial> records = await this.ProductRepository.BillOfMaterialsByProductAssemblyID(productAssemblyID, limit, offset);

			return this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiBillOfMaterialServerResponseModel>> BillOfMaterialsByComponentID(int componentID, int limit = int.MaxValue, int offset = 0)
		{
			List<BillOfMaterial> records = await this.ProductRepository.BillOfMaterialsByComponentID(componentID, limit, offset);

			return this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductReviewServerResponseModel>> ProductReviewsByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductReview> records = await this.ProductRepository.ProductReviewsByProductID(productID, limit, offset);

			return this.BolProductReviewMapper.MapBOToModel(this.DalProductReviewMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTransactionHistoryServerResponseModel>> TransactionHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<TransactionHistory> records = await this.ProductRepository.TransactionHistoriesByProductID(productID, limit, offset);

			return this.BolTransactionHistoryMapper.MapBOToModel(this.DalTransactionHistoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiWorkOrderServerResponseModel>> WorkOrdersByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<WorkOrder> records = await this.ProductRepository.WorkOrdersByProductID(productID, limit, offset);

			return this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>92e8493dfba53f772fd66e811f02f910</Hash>
</Codenesium>*/