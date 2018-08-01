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
	public abstract class AbstractSalesOrderHeaderSalesReasonService : AbstractService
	{
		private ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository;

		private IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator;

		private IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper;

		private IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper;

		private ILogger logger;

		public AbstractSalesOrderHeaderSalesReasonService(
			ILogger logger,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator,
			IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper,
			IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper)
			: base()
		{
			this.salesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
			this.salesOrderHeaderSalesReasonModelValidator = salesOrderHeaderSalesReasonModelValidator;
			this.bolSalesOrderHeaderSalesReasonMapper = bolSalesOrderHeaderSalesReasonMapper;
			this.dalSalesOrderHeaderSalesReasonMapper = dalSalesOrderHeaderSalesReasonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.salesOrderHeaderSalesReasonRepository.All(limit, offset);

			return this.bolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.dalSalesOrderHeaderSalesReasonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesOrderHeaderSalesReasonResponseModel> Get(int salesOrderID)
		{
			var record = await this.salesOrderHeaderSalesReasonRepository.Get(salesOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.dalSalesOrderHeaderSalesReasonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>> Create(
			ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> response = new CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>(await this.salesOrderHeaderSalesReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolSalesOrderHeaderSalesReasonMapper.MapModelToBO(default(int), model);
				var record = await this.salesOrderHeaderSalesReasonRepository.Create(this.dalSalesOrderHeaderSalesReasonMapper.MapBOToEF(bo));

				response.SetRecord(this.bolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.dalSalesOrderHeaderSalesReasonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>> Update(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			var validationResult = await this.salesOrderHeaderSalesReasonModelValidator.ValidateUpdateAsync(salesOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolSalesOrderHeaderSalesReasonMapper.MapModelToBO(salesOrderID, model);
				await this.salesOrderHeaderSalesReasonRepository.Update(this.dalSalesOrderHeaderSalesReasonMapper.MapBOToEF(bo));

				var record = await this.salesOrderHeaderSalesReasonRepository.Get(salesOrderID);

				return new UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>(this.bolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.dalSalesOrderHeaderSalesReasonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>(validationResult);
			}
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
    <Hash>4aac398ff6f0b0af2904ead0b9d18ca5</Hash>
</Codenesium>*/