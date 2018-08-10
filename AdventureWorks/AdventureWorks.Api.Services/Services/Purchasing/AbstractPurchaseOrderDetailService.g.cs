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
	public abstract class AbstractPurchaseOrderDetailService : AbstractService
	{
		protected IPurchaseOrderDetailRepository PurchaseOrderDetailRepository { get; private set; }

		protected IApiPurchaseOrderDetailRequestModelValidator PurchaseOrderDetailModelValidator { get; private set; }

		protected IBOLPurchaseOrderDetailMapper BolPurchaseOrderDetailMapper { get; private set; }

		protected IDALPurchaseOrderDetailMapper DalPurchaseOrderDetailMapper { get; private set; }

		private ILogger logger;

		public AbstractPurchaseOrderDetailService(
			ILogger logger,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator,
			IBOLPurchaseOrderDetailMapper bolPurchaseOrderDetailMapper,
			IDALPurchaseOrderDetailMapper dalPurchaseOrderDetailMapper)
			: base()
		{
			this.PurchaseOrderDetailRepository = purchaseOrderDetailRepository;
			this.PurchaseOrderDetailModelValidator = purchaseOrderDetailModelValidator;
			this.BolPurchaseOrderDetailMapper = bolPurchaseOrderDetailMapper;
			this.DalPurchaseOrderDetailMapper = dalPurchaseOrderDetailMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PurchaseOrderDetailRepository.All(limit, offset);

			return this.BolPurchaseOrderDetailMapper.MapBOToModel(this.DalPurchaseOrderDetailMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPurchaseOrderDetailResponseModel> Get(int purchaseOrderID)
		{
			var record = await this.PurchaseOrderDetailRepository.Get(purchaseOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPurchaseOrderDetailMapper.MapBOToModel(this.DalPurchaseOrderDetailMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPurchaseOrderDetailResponseModel>> Create(
			ApiPurchaseOrderDetailRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderDetailResponseModel> response = new CreateResponse<ApiPurchaseOrderDetailResponseModel>(await this.PurchaseOrderDetailModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPurchaseOrderDetailMapper.MapModelToBO(default(int), model);
				var record = await this.PurchaseOrderDetailRepository.Create(this.DalPurchaseOrderDetailMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPurchaseOrderDetailMapper.MapBOToModel(this.DalPurchaseOrderDetailMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPurchaseOrderDetailResponseModel>> Update(
			int purchaseOrderID,
			ApiPurchaseOrderDetailRequestModel model)
		{
			var validationResult = await this.PurchaseOrderDetailModelValidator.ValidateUpdateAsync(purchaseOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPurchaseOrderDetailMapper.MapModelToBO(purchaseOrderID, model);
				await this.PurchaseOrderDetailRepository.Update(this.DalPurchaseOrderDetailMapper.MapBOToEF(bo));

				var record = await this.PurchaseOrderDetailRepository.Get(purchaseOrderID);

				return new UpdateResponse<ApiPurchaseOrderDetailResponseModel>(this.BolPurchaseOrderDetailMapper.MapBOToModel(this.DalPurchaseOrderDetailMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPurchaseOrderDetailResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int purchaseOrderID)
		{
			ActionResponse response = new ActionResponse(await this.PurchaseOrderDetailModelValidator.ValidateDeleteAsync(purchaseOrderID));
			if (response.Success)
			{
				await this.PurchaseOrderDetailRepository.Delete(purchaseOrderID);
			}

			return response;
		}

		public async Task<List<ApiPurchaseOrderDetailResponseModel>> ByProductID(int productID)
		{
			List<PurchaseOrderDetail> records = await this.PurchaseOrderDetailRepository.ByProductID(productID);

			return this.BolPurchaseOrderDetailMapper.MapBOToModel(this.DalPurchaseOrderDetailMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>232b5345bc755526ac54893bb7997065</Hash>
</Codenesium>*/