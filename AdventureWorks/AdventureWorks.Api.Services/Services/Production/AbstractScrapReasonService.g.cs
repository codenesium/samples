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
	public abstract class AbstractScrapReasonService : AbstractService
	{
		protected IScrapReasonRepository ScrapReasonRepository { get; private set; }

		protected IApiScrapReasonRequestModelValidator ScrapReasonModelValidator { get; private set; }

		protected IBOLScrapReasonMapper BolScrapReasonMapper { get; private set; }

		protected IDALScrapReasonMapper DalScrapReasonMapper { get; private set; }

		protected IBOLWorkOrderMapper BolWorkOrderMapper { get; private set; }

		protected IDALWorkOrderMapper DalWorkOrderMapper { get; private set; }

		private ILogger logger;

		public AbstractScrapReasonService(
			ILogger logger,
			IScrapReasonRepository scrapReasonRepository,
			IApiScrapReasonRequestModelValidator scrapReasonModelValidator,
			IBOLScrapReasonMapper bolScrapReasonMapper,
			IDALScrapReasonMapper dalScrapReasonMapper,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base()
		{
			this.ScrapReasonRepository = scrapReasonRepository;
			this.ScrapReasonModelValidator = scrapReasonModelValidator;
			this.BolScrapReasonMapper = bolScrapReasonMapper;
			this.DalScrapReasonMapper = dalScrapReasonMapper;
			this.BolWorkOrderMapper = bolWorkOrderMapper;
			this.DalWorkOrderMapper = dalWorkOrderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiScrapReasonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ScrapReasonRepository.All(limit, offset);

			return this.BolScrapReasonMapper.MapBOToModel(this.DalScrapReasonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiScrapReasonResponseModel> Get(short scrapReasonID)
		{
			var record = await this.ScrapReasonRepository.Get(scrapReasonID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolScrapReasonMapper.MapBOToModel(this.DalScrapReasonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiScrapReasonResponseModel>> Create(
			ApiScrapReasonRequestModel model)
		{
			CreateResponse<ApiScrapReasonResponseModel> response = new CreateResponse<ApiScrapReasonResponseModel>(await this.ScrapReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolScrapReasonMapper.MapModelToBO(default(short), model);
				var record = await this.ScrapReasonRepository.Create(this.DalScrapReasonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolScrapReasonMapper.MapBOToModel(this.DalScrapReasonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiScrapReasonResponseModel>> Update(
			short scrapReasonID,
			ApiScrapReasonRequestModel model)
		{
			var validationResult = await this.ScrapReasonModelValidator.ValidateUpdateAsync(scrapReasonID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolScrapReasonMapper.MapModelToBO(scrapReasonID, model);
				await this.ScrapReasonRepository.Update(this.DalScrapReasonMapper.MapBOToEF(bo));

				var record = await this.ScrapReasonRepository.Get(scrapReasonID);

				return new UpdateResponse<ApiScrapReasonResponseModel>(this.BolScrapReasonMapper.MapBOToModel(this.DalScrapReasonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiScrapReasonResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			short scrapReasonID)
		{
			ActionResponse response = new ActionResponse(await this.ScrapReasonModelValidator.ValidateDeleteAsync(scrapReasonID));
			if (response.Success)
			{
				await this.ScrapReasonRepository.Delete(scrapReasonID);
			}

			return response;
		}

		public async Task<ApiScrapReasonResponseModel> ByName(string name)
		{
			ScrapReason record = await this.ScrapReasonRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolScrapReasonMapper.MapBOToModel(this.DalScrapReasonMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiWorkOrderResponseModel>> WorkOrdersByScrapReasonID(short scrapReasonID, int limit = int.MaxValue, int offset = 0)
		{
			List<WorkOrder> records = await this.ScrapReasonRepository.WorkOrdersByScrapReasonID(scrapReasonID, limit, offset);

			return this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>cadd3173a60a8a99140bf7e71c25d889</Hash>
</Codenesium>*/