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

		protected IDALProductMapper DalProductMapper { get; private set; }

		protected IDALBillOfMaterialMapper DalBillOfMaterialMapper { get; private set; }

		protected IDALProductReviewMapper DalProductReviewMapper { get; private set; }

		protected IDALTransactionHistoryMapper DalTransactionHistoryMapper { get; private set; }

		protected IDALWorkOrderMapper DalWorkOrderMapper { get; private set; }

		private ILogger logger;

		public AbstractProductService(
			ILogger logger,
			IMediator mediator,
			IProductRepository productRepository,
			IApiProductServerRequestModelValidator productModelValidator,
			IDALProductMapper dalProductMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper,
			IDALProductReviewMapper dalProductReviewMapper,
			IDALTransactionHistoryMapper dalTransactionHistoryMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base()
		{
			this.ProductRepository = productRepository;
			this.ProductModelValidator = productModelValidator;
			this.DalProductMapper = dalProductMapper;
			this.DalBillOfMaterialMapper = dalBillOfMaterialMapper;
			this.DalProductReviewMapper = dalProductReviewMapper;
			this.DalTransactionHistoryMapper = dalTransactionHistoryMapper;
			this.DalWorkOrderMapper = dalWorkOrderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProductServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.ProductRepository.All(limit, offset, query);

			return this.DalProductMapper.MapBOToModel(records);
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
				return this.DalProductMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiProductServerResponseModel>> Create(
			ApiProductServerRequestModel model)
		{
			CreateResponse<ApiProductServerResponseModel> response = ValidationResponseFactory<ApiProductServerResponseModel>.CreateResponse(await this.ProductModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalProductMapper.MapModelToBO(default(int), model);
				var record = await this.ProductRepository.Create(bo);

				response.SetRecord(this.DalProductMapper.MapBOToModel(record));
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
				var bo = this.DalProductMapper.MapModelToBO(productID, model);
				await this.ProductRepository.Update(bo);

				var record = await this.ProductRepository.Get(productID);

				var apiModel = this.DalProductMapper.MapBOToModel(record);
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
				return this.DalProductMapper.MapBOToModel(record);
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
				return this.DalProductMapper.MapBOToModel(record);
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
				return this.DalProductMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiBillOfMaterialServerResponseModel>> BillOfMaterialsByProductAssemblyID(int productAssemblyID, int limit = int.MaxValue, int offset = 0)
		{
			List<BillOfMaterial> records = await this.ProductRepository.BillOfMaterialsByProductAssemblyID(productAssemblyID, limit, offset);

			return this.DalBillOfMaterialMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiBillOfMaterialServerResponseModel>> BillOfMaterialsByComponentID(int componentID, int limit = int.MaxValue, int offset = 0)
		{
			List<BillOfMaterial> records = await this.ProductRepository.BillOfMaterialsByComponentID(componentID, limit, offset);

			return this.DalBillOfMaterialMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiProductReviewServerResponseModel>> ProductReviewsByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductReview> records = await this.ProductRepository.ProductReviewsByProductID(productID, limit, offset);

			return this.DalProductReviewMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiTransactionHistoryServerResponseModel>> TransactionHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<TransactionHistory> records = await this.ProductRepository.TransactionHistoriesByProductID(productID, limit, offset);

			return this.DalTransactionHistoryMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiWorkOrderServerResponseModel>> WorkOrdersByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<WorkOrder> records = await this.ProductRepository.WorkOrdersByProductID(productID, limit, offset);

			return this.DalWorkOrderMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>6c0d2f96c4bc9dcdfcff36533c86ba36</Hash>
</Codenesium>*/