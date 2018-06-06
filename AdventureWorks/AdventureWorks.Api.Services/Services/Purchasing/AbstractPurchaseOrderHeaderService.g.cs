using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPurchaseOrderHeaderService: AbstractService
	{
		private IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository;
		private IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator;
		private IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper;
		private IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper;
		private ILogger logger;

		public AbstractPurchaseOrderHeaderService(
			ILogger logger,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator,
			IBOLPurchaseOrderHeaderMapper bolpurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalpurchaseOrderHeaderMapper)
			: base()

		{
			this.purchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
			this.purchaseOrderHeaderModelValidator = purchaseOrderHeaderModelValidator;
			this.bolPurchaseOrderHeaderMapper = bolpurchaseOrderHeaderMapper;
			this.dalPurchaseOrderHeaderMapper = dalpurchaseOrderHeaderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.purchaseOrderHeaderRepository.All(skip, take, orderClause);

			return this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPurchaseOrderHeaderResponseModel> Get(int purchaseOrderID)
		{
			var record = await purchaseOrderHeaderRepository.Get(purchaseOrderID);

			return this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPurchaseOrderHeaderResponseModel>> Create(
			ApiPurchaseOrderHeaderRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderHeaderResponseModel> response = new CreateResponse<ApiPurchaseOrderHeaderResponseModel>(await this.purchaseOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolPurchaseOrderHeaderMapper.MapModelToBO(default (int), model);
				var record = await this.purchaseOrderHeaderRepository.Create(this.dalPurchaseOrderHeaderMapper.MapBOToEF(bo));

				response.SetRecord(this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderHeaderModelValidator.ValidateUpdateAsync(purchaseOrderID, model));

			if (response.Success)
			{
				var bo = this.bolPurchaseOrderHeaderMapper.MapModelToBO(purchaseOrderID, model);
				await this.purchaseOrderHeaderRepository.Update(this.dalPurchaseOrderHeaderMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int purchaseOrderID)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderHeaderModelValidator.ValidateDeleteAsync(purchaseOrderID));

			if (response.Success)
			{
				await this.purchaseOrderHeaderRepository.Delete(purchaseOrderID);
			}
			return response;
		}

		public async Task<List<ApiPurchaseOrderHeaderResponseModel>> GetEmployeeID(int employeeID)
		{
			List<PurchaseOrderHeader> records = await this.purchaseOrderHeaderRepository.GetEmployeeID(employeeID);

			return this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}
		public async Task<List<ApiPurchaseOrderHeaderResponseModel>> GetVendorID(int vendorID)
		{
			List<PurchaseOrderHeader> records = await this.purchaseOrderHeaderRepository.GetVendorID(vendorID);

			return this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>5a5b0e910378f2ed187483fe402299ad</Hash>
</Codenesium>*/