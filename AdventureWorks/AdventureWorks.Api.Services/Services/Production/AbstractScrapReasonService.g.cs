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
	public abstract class AbstractScrapReasonService: AbstractService
	{
		private IScrapReasonRepository scrapReasonRepository;
		private IApiScrapReasonRequestModelValidator scrapReasonModelValidator;
		private IBOLScrapReasonMapper bolScrapReasonMapper;
		private IDALScrapReasonMapper dalScrapReasonMapper;
		private ILogger logger;

		public AbstractScrapReasonService(
			ILogger logger,
			IScrapReasonRepository scrapReasonRepository,
			IApiScrapReasonRequestModelValidator scrapReasonModelValidator,
			IBOLScrapReasonMapper bolscrapReasonMapper,
			IDALScrapReasonMapper dalscrapReasonMapper)
			: base()

		{
			this.scrapReasonRepository = scrapReasonRepository;
			this.scrapReasonModelValidator = scrapReasonModelValidator;
			this.bolScrapReasonMapper = bolscrapReasonMapper;
			this.dalScrapReasonMapper = dalscrapReasonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiScrapReasonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.scrapReasonRepository.All(skip, take, orderClause);

			return this.bolScrapReasonMapper.MapBOToModel(this.dalScrapReasonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiScrapReasonResponseModel> Get(short scrapReasonID)
		{
			var record = await scrapReasonRepository.Get(scrapReasonID);

			return this.bolScrapReasonMapper.MapBOToModel(this.dalScrapReasonMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiScrapReasonResponseModel>> Create(
			ApiScrapReasonRequestModel model)
		{
			CreateResponse<ApiScrapReasonResponseModel> response = new CreateResponse<ApiScrapReasonResponseModel>(await this.scrapReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolScrapReasonMapper.MapModelToBO(default (short), model);
				var record = await this.scrapReasonRepository.Create(this.dalScrapReasonMapper.MapBOToEF(bo));

				response.SetRecord(this.bolScrapReasonMapper.MapBOToModel(this.dalScrapReasonMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			short scrapReasonID,
			ApiScrapReasonRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.scrapReasonModelValidator.ValidateUpdateAsync(scrapReasonID, model));

			if (response.Success)
			{
				var bo = this.bolScrapReasonMapper.MapModelToBO(scrapReasonID, model);
				await this.scrapReasonRepository.Update(this.dalScrapReasonMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			short scrapReasonID)
		{
			ActionResponse response = new ActionResponse(await this.scrapReasonModelValidator.ValidateDeleteAsync(scrapReasonID));

			if (response.Success)
			{
				await this.scrapReasonRepository.Delete(scrapReasonID);
			}
			return response;
		}

		public async Task<ApiScrapReasonResponseModel> GetName(string name)
		{
			ScrapReason record = await this.scrapReasonRepository.GetName(name);

			return this.bolScrapReasonMapper.MapBOToModel(this.dalScrapReasonMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>480ff0015b4ac2afb07bd862309881ed</Hash>
</Codenesium>*/