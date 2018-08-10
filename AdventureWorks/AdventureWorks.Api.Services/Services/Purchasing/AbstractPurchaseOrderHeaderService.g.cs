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
	public abstract class AbstractPurchaseOrderHeaderService : AbstractService
	{
		protected IPurchaseOrderHeaderRepository PurchaseOrderHeaderRepository { get; private set; }

		protected IApiPurchaseOrderHeaderRequestModelValidator PurchaseOrderHeaderModelValidator { get; private set; }

		protected IBOLPurchaseOrderHeaderMapper BolPurchaseOrderHeaderMapper { get; private set; }

		protected IDALPurchaseOrderHeaderMapper DalPurchaseOrderHeaderMapper { get; private set; }

		protected IBOLPurchaseOrderDetailMapper BolPurchaseOrderDetailMapper { get; private set; }

		protected IDALPurchaseOrderDetailMapper DalPurchaseOrderDetailMapper { get; private set; }

		private ILogger logger;

		public AbstractPurchaseOrderHeaderService(
			ILogger logger,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper,
			IBOLPurchaseOrderDetailMapper bolPurchaseOrderDetailMapper,
			IDALPurchaseOrderDetailMapper dalPurchaseOrderDetailMapper)
			: base()
		{
			this.PurchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
			this.PurchaseOrderHeaderModelValidator = purchaseOrderHeaderModelValidator;
			this.BolPurchaseOrderHeaderMapper = bolPurchaseOrderHeaderMapper;
			this.DalPurchaseOrderHeaderMapper = dalPurchaseOrderHeaderMapper;
			this.BolPurchaseOrderDetailMapper = bolPurchaseOrderDetailMapper;
			this.DalPurchaseOrderDetailMapper = dalPurchaseOrderDetailMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PurchaseOrderHeaderRepository.All(limit, offset);

			return this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPurchaseOrderHeaderResponseModel> Get(int purchaseOrderID)
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

		public virtual async Task<CreateResponse<ApiPurchaseOrderHeaderResponseModel>> Create(
			ApiPurchaseOrderHeaderRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderHeaderResponseModel> response = new CreateResponse<ApiPurchaseOrderHeaderResponseModel>(await this.PurchaseOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPurchaseOrderHeaderMapper.MapModelToBO(default(int), model);
				var record = await this.PurchaseOrderHeaderRepository.Create(this.DalPurchaseOrderHeaderMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPurchaseOrderHeaderResponseModel>> Update(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderRequestModel model)
		{
			var validationResult = await this.PurchaseOrderHeaderModelValidator.ValidateUpdateAsync(purchaseOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPurchaseOrderHeaderMapper.MapModelToBO(purchaseOrderID, model);
				await this.PurchaseOrderHeaderRepository.Update(this.DalPurchaseOrderHeaderMapper.MapBOToEF(bo));

				var record = await this.PurchaseOrderHeaderRepository.Get(purchaseOrderID);

				return new UpdateResponse<ApiPurchaseOrderHeaderResponseModel>(this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPurchaseOrderHeaderResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int purchaseOrderID)
		{
			ActionResponse response = new ActionResponse(await this.PurchaseOrderHeaderModelValidator.ValidateDeleteAsync(purchaseOrderID));
			if (response.Success)
			{
				await this.PurchaseOrderHeaderRepository.Delete(purchaseOrderID);
			}

			return response;
		}

		public async Task<List<ApiPurchaseOrderHeaderResponseModel>> ByEmployeeID(int employeeID)
		{
			List<PurchaseOrderHeader> records = await this.PurchaseOrderHeaderRepository.ByEmployeeID(employeeID);

			return this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}

		public async Task<List<ApiPurchaseOrderHeaderResponseModel>> ByVendorID(int vendorID)
		{
			List<PurchaseOrderHeader> records = await this.PurchaseOrderHeaderRepository.ByVendorID(vendorID);

			return this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPurchaseOrderDetailResponseModel>> PurchaseOrderDetails(int purchaseOrderID, int limit = int.MaxValue, int offset = 0)
		{
			List<PurchaseOrderDetail> records = await this.PurchaseOrderHeaderRepository.PurchaseOrderDetails(purchaseOrderID, limit, offset);

			return this.BolPurchaseOrderDetailMapper.MapBOToModel(this.DalPurchaseOrderDetailMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>9a009b75280d9edd1d18a1a71d8cb9f1</Hash>
</Codenesium>*/