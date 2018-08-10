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
		protected ISalesOrderHeaderSalesReasonRepository SalesOrderHeaderSalesReasonRepository { get; private set; }

		protected IApiSalesOrderHeaderSalesReasonRequestModelValidator SalesOrderHeaderSalesReasonModelValidator { get; private set; }

		protected IBOLSalesOrderHeaderSalesReasonMapper BolSalesOrderHeaderSalesReasonMapper { get; private set; }

		protected IDALSalesOrderHeaderSalesReasonMapper DalSalesOrderHeaderSalesReasonMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesOrderHeaderSalesReasonService(
			ILogger logger,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator,
			IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper,
			IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper)
			: base()
		{
			this.SalesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
			this.SalesOrderHeaderSalesReasonModelValidator = salesOrderHeaderSalesReasonModelValidator;
			this.BolSalesOrderHeaderSalesReasonMapper = bolSalesOrderHeaderSalesReasonMapper;
			this.DalSalesOrderHeaderSalesReasonMapper = dalSalesOrderHeaderSalesReasonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesOrderHeaderSalesReasonRepository.All(limit, offset);

			return this.BolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.DalSalesOrderHeaderSalesReasonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesOrderHeaderSalesReasonResponseModel> Get(int salesOrderID)
		{
			var record = await this.SalesOrderHeaderSalesReasonRepository.Get(salesOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.DalSalesOrderHeaderSalesReasonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>> Create(
			ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> response = new CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>(await this.SalesOrderHeaderSalesReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSalesOrderHeaderSalesReasonMapper.MapModelToBO(default(int), model);
				var record = await this.SalesOrderHeaderSalesReasonRepository.Create(this.DalSalesOrderHeaderSalesReasonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.DalSalesOrderHeaderSalesReasonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>> Update(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			var validationResult = await this.SalesOrderHeaderSalesReasonModelValidator.ValidateUpdateAsync(salesOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesOrderHeaderSalesReasonMapper.MapModelToBO(salesOrderID, model);
				await this.SalesOrderHeaderSalesReasonRepository.Update(this.DalSalesOrderHeaderSalesReasonMapper.MapBOToEF(bo));

				var record = await this.SalesOrderHeaderSalesReasonRepository.Get(salesOrderID);

				return new UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>(this.BolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.DalSalesOrderHeaderSalesReasonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.SalesOrderHeaderSalesReasonModelValidator.ValidateDeleteAsync(salesOrderID));
			if (response.Success)
			{
				await this.SalesOrderHeaderSalesReasonRepository.Delete(salesOrderID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c005557c47db73754f6e354b23397654</Hash>
</Codenesium>*/