using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractHandlerPipelineStepService: AbstractService
	{
		private IHandlerPipelineStepRepository handlerPipelineStepRepository;
		private IApiHandlerPipelineStepRequestModelValidator handlerPipelineStepModelValidator;
		private IBOLHandlerPipelineStepMapper BOLHandlerPipelineStepMapper;
		private IDALHandlerPipelineStepMapper DALHandlerPipelineStepMapper;
		private ILogger logger;

		public AbstractHandlerPipelineStepService(
			ILogger logger,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IApiHandlerPipelineStepRequestModelValidator handlerPipelineStepModelValidator,
			IBOLHandlerPipelineStepMapper bolhandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalhandlerPipelineStepMapper)
			: base()

		{
			this.handlerPipelineStepRepository = handlerPipelineStepRepository;
			this.handlerPipelineStepModelValidator = handlerPipelineStepModelValidator;
			this.BOLHandlerPipelineStepMapper = bolhandlerPipelineStepMapper;
			this.DALHandlerPipelineStepMapper = dalhandlerPipelineStepMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiHandlerPipelineStepResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.handlerPipelineStepRepository.All(skip, take, orderClause);

			return this.BOLHandlerPipelineStepMapper.MapBOToModel(this.DALHandlerPipelineStepMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiHandlerPipelineStepResponseModel> Get(int id)
		{
			var record = await handlerPipelineStepRepository.Get(id);

			return this.BOLHandlerPipelineStepMapper.MapBOToModel(this.DALHandlerPipelineStepMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiHandlerPipelineStepResponseModel>> Create(
			ApiHandlerPipelineStepRequestModel model)
		{
			CreateResponse<ApiHandlerPipelineStepResponseModel> response = new CreateResponse<ApiHandlerPipelineStepResponseModel>(await this.handlerPipelineStepModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLHandlerPipelineStepMapper.MapModelToBO(default (int), model);
				var record = await this.handlerPipelineStepRepository.Create(this.DALHandlerPipelineStepMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLHandlerPipelineStepMapper.MapBOToModel(this.DALHandlerPipelineStepMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiHandlerPipelineStepRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.handlerPipelineStepModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLHandlerPipelineStepMapper.MapModelToBO(id, model);
				await this.handlerPipelineStepRepository.Update(this.DALHandlerPipelineStepMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.handlerPipelineStepModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.handlerPipelineStepRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>12285d77d14116df9c8ded0c1a3e3d1a</Hash>
</Codenesium>*/