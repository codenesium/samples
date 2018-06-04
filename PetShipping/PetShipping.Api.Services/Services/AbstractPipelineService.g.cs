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
	public abstract class AbstractPipelineService: AbstractService
	{
		private IPipelineRepository pipelineRepository;
		private IApiPipelineRequestModelValidator pipelineModelValidator;
		private IBOLPipelineMapper BOLPipelineMapper;
		private IDALPipelineMapper DALPipelineMapper;
		private ILogger logger;

		public AbstractPipelineService(
			ILogger logger,
			IPipelineRepository pipelineRepository,
			IApiPipelineRequestModelValidator pipelineModelValidator,
			IBOLPipelineMapper bolpipelineMapper,
			IDALPipelineMapper dalpipelineMapper)
			: base()

		{
			this.pipelineRepository = pipelineRepository;
			this.pipelineModelValidator = pipelineModelValidator;
			this.BOLPipelineMapper = bolpipelineMapper;
			this.DALPipelineMapper = dalpipelineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineRepository.All(skip, take, orderClause);

			return this.BOLPipelineMapper.MapBOToModel(this.DALPipelineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineResponseModel> Get(int id)
		{
			var record = await pipelineRepository.Get(id);

			return this.BOLPipelineMapper.MapBOToModel(this.DALPipelineMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPipelineResponseModel>> Create(
			ApiPipelineRequestModel model)
		{
			CreateResponse<ApiPipelineResponseModel> response = new CreateResponse<ApiPipelineResponseModel>(await this.pipelineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLPipelineMapper.MapModelToBO(default (int), model);
				var record = await this.pipelineRepository.Create(this.DALPipelineMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLPipelineMapper.MapBOToModel(this.DALPipelineMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLPipelineMapper.MapModelToBO(id, model);
				await this.pipelineRepository.Update(this.DALPipelineMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>03a8edb72b80477715cd030494223950</Hash>
</Codenesium>*/