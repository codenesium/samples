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
		private IBOLScrapReasonMapper BOLScrapReasonMapper;
		private IDALScrapReasonMapper DALScrapReasonMapper;
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
			this.BOLScrapReasonMapper = bolscrapReasonMapper;
			this.DALScrapReasonMapper = dalscrapReasonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiScrapReasonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.scrapReasonRepository.All(skip, take, orderClause);

			return this.BOLScrapReasonMapper.MapBOToModel(this.DALScrapReasonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiScrapReasonResponseModel> Get(short scrapReasonID)
		{
			var record = await scrapReasonRepository.Get(scrapReasonID);

			return this.BOLScrapReasonMapper.MapBOToModel(this.DALScrapReasonMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiScrapReasonResponseModel>> Create(
			ApiScrapReasonRequestModel model)
		{
			CreateResponse<ApiScrapReasonResponseModel> response = new CreateResponse<ApiScrapReasonResponseModel>(await this.scrapReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLScrapReasonMapper.MapModelToBO(default (short), model);
				var record = await this.scrapReasonRepository.Create(this.DALScrapReasonMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLScrapReasonMapper.MapBOToModel(this.DALScrapReasonMapper.MapEFToBO(record)));
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
				var bo = this.BOLScrapReasonMapper.MapModelToBO(scrapReasonID, model);
				await this.scrapReasonRepository.Update(this.DALScrapReasonMapper.MapBOToEF(bo));
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

			return this.BOLScrapReasonMapper.MapBOToModel(this.DALScrapReasonMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>568911db94cf3f5c5f9796d01058dcd0</Hash>
</Codenesium>*/