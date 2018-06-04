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
	public abstract class AbstractPipelineStatusService: AbstractService
	{
		private IPipelineStatusRepository pipelineStatusRepository;
		private IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator;
		private IBOLPipelineStatusMapper BOLPipelineStatusMapper;
		private IDALPipelineStatusMapper DALPipelineStatusMapper;
		private ILogger logger;

		public AbstractPipelineStatusService(
			ILogger logger,
			IPipelineStatusRepository pipelineStatusRepository,
			IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator,
			IBOLPipelineStatusMapper bolpipelineStatusMapper,
			IDALPipelineStatusMapper dalpipelineStatusMapper)
			: base()

		{
			this.pipelineStatusRepository = pipelineStatusRepository;
			this.pipelineStatusModelValidator = pipelineStatusModelValidator;
			this.BOLPipelineStatusMapper = bolpipelineStatusMapper;
			this.DALPipelineStatusMapper = dalpipelineStatusMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineStatusRepository.All(skip, take, orderClause);

			return this.BOLPipelineStatusMapper.MapBOToModel(this.DALPipelineStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStatusResponseModel> Get(int id)
		{
			var record = await pipelineStatusRepository.Get(id);

			return this.BOLPipelineStatusMapper.MapBOToModel(this.DALPipelineStatusMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPipelineStatusResponseModel>> Create(
			ApiPipelineStatusRequestModel model)
		{
			CreateResponse<ApiPipelineStatusResponseModel> response = new CreateResponse<ApiPipelineStatusResponseModel>(await this.pipelineStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLPipelineStatusMapper.MapModelToBO(default (int), model);
				var record = await this.pipelineStatusRepository.Create(this.DALPipelineStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLPipelineStatusMapper.MapBOToModel(this.DALPipelineStatusMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStatusRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLPipelineStatusMapper.MapModelToBO(id, model);
				await this.pipelineStatusRepository.Update(this.DALPipelineStatusMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineStatusRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a926ebbbf560a733cb1a770ef5bc7f9d</Hash>
</Codenesium>*/