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

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOScrapReason: AbstractBOManager
	{
		private IScrapReasonRepository scrapReasonRepository;
		private IApiScrapReasonRequestModelValidator scrapReasonModelValidator;
		private IBOLScrapReasonMapper scrapReasonMapper;
		private ILogger logger;

		public AbstractBOScrapReason(
			ILogger logger,
			IScrapReasonRepository scrapReasonRepository,
			IApiScrapReasonRequestModelValidator scrapReasonModelValidator,
			IBOLScrapReasonMapper scrapReasonMapper)
			: base()

		{
			this.scrapReasonRepository = scrapReasonRepository;
			this.scrapReasonModelValidator = scrapReasonModelValidator;
			this.scrapReasonMapper = scrapReasonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiScrapReasonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.scrapReasonRepository.All(skip, take, orderClause);

			return this.scrapReasonMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiScrapReasonResponseModel> Get(short scrapReasonID)
		{
			var record = await scrapReasonRepository.Get(scrapReasonID);

			return this.scrapReasonMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiScrapReasonResponseModel>> Create(
			ApiScrapReasonRequestModel model)
		{
			CreateResponse<ApiScrapReasonResponseModel> response = new CreateResponse<ApiScrapReasonResponseModel>(await this.scrapReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.scrapReasonMapper.MapModelToDTO(default (short), model);
				var record = await this.scrapReasonRepository.Create(dto);

				response.SetRecord(this.scrapReasonMapper.MapDTOToModel(record));
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
				var dto = this.scrapReasonMapper.MapModelToDTO(scrapReasonID, model);
				await this.scrapReasonRepository.Update(scrapReasonID, dto);
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
			DTOScrapReason record = await this.scrapReasonRepository.GetName(name);

			return this.scrapReasonMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>eb276e8d8a7a7c73c109a6bf0eeae536</Hash>
</Codenesium>*/