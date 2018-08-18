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
	public abstract class AbstractSalesReasonService : AbstractService
	{
		protected ISalesReasonRepository SalesReasonRepository { get; private set; }

		protected IApiSalesReasonRequestModelValidator SalesReasonModelValidator { get; private set; }

		protected IBOLSalesReasonMapper BolSalesReasonMapper { get; private set; }

		protected IDALSalesReasonMapper DalSalesReasonMapper { get; private set; }

		protected IBOLSalesOrderHeaderSalesReasonMapper BolSalesOrderHeaderSalesReasonMapper { get; private set; }

		protected IDALSalesOrderHeaderSalesReasonMapper DalSalesOrderHeaderSalesReasonMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesReasonService(
			ILogger logger,
			ISalesReasonRepository salesReasonRepository,
			IApiSalesReasonRequestModelValidator salesReasonModelValidator,
			IBOLSalesReasonMapper bolSalesReasonMapper,
			IDALSalesReasonMapper dalSalesReasonMapper,
			IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper,
			IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper)
			: base()
		{
			this.SalesReasonRepository = salesReasonRepository;
			this.SalesReasonModelValidator = salesReasonModelValidator;
			this.BolSalesReasonMapper = bolSalesReasonMapper;
			this.DalSalesReasonMapper = dalSalesReasonMapper;
			this.BolSalesOrderHeaderSalesReasonMapper = bolSalesOrderHeaderSalesReasonMapper;
			this.DalSalesOrderHeaderSalesReasonMapper = dalSalesOrderHeaderSalesReasonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesReasonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesReasonRepository.All(limit, offset);

			return this.BolSalesReasonMapper.MapBOToModel(this.DalSalesReasonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesReasonResponseModel> Get(int salesReasonID)
		{
			var record = await this.SalesReasonRepository.Get(salesReasonID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesReasonMapper.MapBOToModel(this.DalSalesReasonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesReasonResponseModel>> Create(
			ApiSalesReasonRequestModel model)
		{
			CreateResponse<ApiSalesReasonResponseModel> response = new CreateResponse<ApiSalesReasonResponseModel>(await this.SalesReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSalesReasonMapper.MapModelToBO(default(int), model);
				var record = await this.SalesReasonRepository.Create(this.DalSalesReasonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSalesReasonMapper.MapBOToModel(this.DalSalesReasonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesReasonResponseModel>> Update(
			int salesReasonID,
			ApiSalesReasonRequestModel model)
		{
			var validationResult = await this.SalesReasonModelValidator.ValidateUpdateAsync(salesReasonID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesReasonMapper.MapModelToBO(salesReasonID, model);
				await this.SalesReasonRepository.Update(this.DalSalesReasonMapper.MapBOToEF(bo));

				var record = await this.SalesReasonRepository.Get(salesReasonID);

				return new UpdateResponse<ApiSalesReasonResponseModel>(this.BolSalesReasonMapper.MapBOToModel(this.DalSalesReasonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSalesReasonResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int salesReasonID)
		{
			ActionResponse response = new ActionResponse(await this.SalesReasonModelValidator.ValidateDeleteAsync(salesReasonID));
			if (response.Success)
			{
				await this.SalesReasonRepository.Delete(salesReasonID);
			}

			return response;
		}

		public async virtual Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> SalesOrderHeaderSalesReasons(int salesReasonID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeaderSalesReason> records = await this.SalesReasonRepository.SalesOrderHeaderSalesReasons(salesReasonID, limit, offset);

			return this.BolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.DalSalesOrderHeaderSalesReasonMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>178dbe42b96e4acd67b9a5cc6eca8982</Hash>
</Codenesium>*/