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
	public abstract class AbstractSalesOrderHeaderSalesReasonService: AbstractService
	{
		private ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository;
		private IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator;
		private IBOLSalesOrderHeaderSalesReasonMapper BOLSalesOrderHeaderSalesReasonMapper;
		private IDALSalesOrderHeaderSalesReasonMapper DALSalesOrderHeaderSalesReasonMapper;
		private ILogger logger;

		public AbstractSalesOrderHeaderSalesReasonService(
			ILogger logger,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator,
			IBOLSalesOrderHeaderSalesReasonMapper bolsalesOrderHeaderSalesReasonMapper,
			IDALSalesOrderHeaderSalesReasonMapper dalsalesOrderHeaderSalesReasonMapper)
			: base()

		{
			this.salesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
			this.salesOrderHeaderSalesReasonModelValidator = salesOrderHeaderSalesReasonModelValidator;
			this.BOLSalesOrderHeaderSalesReasonMapper = bolsalesOrderHeaderSalesReasonMapper;
			this.DALSalesOrderHeaderSalesReasonMapper = dalsalesOrderHeaderSalesReasonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesOrderHeaderSalesReasonRepository.All(skip, take, orderClause);

			return this.BOLSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.DALSalesOrderHeaderSalesReasonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesOrderHeaderSalesReasonResponseModel> Get(int salesOrderID)
		{
			var record = await salesOrderHeaderSalesReasonRepository.Get(salesOrderID);

			return this.BOLSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.DALSalesOrderHeaderSalesReasonMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>> Create(
			ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> response = new CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>(await this.salesOrderHeaderSalesReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSalesOrderHeaderSalesReasonMapper.MapModelToBO(default (int), model);
				var record = await this.salesOrderHeaderSalesReasonRepository.Create(this.DALSalesOrderHeaderSalesReasonMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.DALSalesOrderHeaderSalesReasonMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderSalesReasonModelValidator.ValidateUpdateAsync(salesOrderID, model));

			if (response.Success)
			{
				var bo = this.BOLSalesOrderHeaderSalesReasonMapper.MapModelToBO(salesOrderID, model);
				await this.salesOrderHeaderSalesReasonRepository.Update(this.DALSalesOrderHeaderSalesReasonMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderSalesReasonModelValidator.ValidateDeleteAsync(salesOrderID));

			if (response.Success)
			{
				await this.salesOrderHeaderSalesReasonRepository.Delete(salesOrderID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5e0e0356125a62aef1ceae4e0dbd78b8</Hash>
</Codenesium>*/