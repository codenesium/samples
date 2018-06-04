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
	public abstract class AbstractPipelineStepNoteService: AbstractService
	{
		private IPipelineStepNoteRepository pipelineStepNoteRepository;
		private IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator;
		private IBOLPipelineStepNoteMapper BOLPipelineStepNoteMapper;
		private IDALPipelineStepNoteMapper DALPipelineStepNoteMapper;
		private ILogger logger;

		public AbstractPipelineStepNoteService(
			ILogger logger,
			IPipelineStepNoteRepository pipelineStepNoteRepository,
			IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator,
			IBOLPipelineStepNoteMapper bolpipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalpipelineStepNoteMapper)
			: base()

		{
			this.pipelineStepNoteRepository = pipelineStepNoteRepository;
			this.pipelineStepNoteModelValidator = pipelineStepNoteModelValidator;
			this.BOLPipelineStepNoteMapper = bolpipelineStepNoteMapper;
			this.DALPipelineStepNoteMapper = dalpipelineStepNoteMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepNoteResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineStepNoteRepository.All(skip, take, orderClause);

			return this.BOLPipelineStepNoteMapper.MapBOToModel(this.DALPipelineStepNoteMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStepNoteResponseModel> Get(int id)
		{
			var record = await pipelineStepNoteRepository.Get(id);

			return this.BOLPipelineStepNoteMapper.MapBOToModel(this.DALPipelineStepNoteMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPipelineStepNoteResponseModel>> Create(
			ApiPipelineStepNoteRequestModel model)
		{
			CreateResponse<ApiPipelineStepNoteResponseModel> response = new CreateResponse<ApiPipelineStepNoteResponseModel>(await this.pipelineStepNoteModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLPipelineStepNoteMapper.MapModelToBO(default (int), model);
				var record = await this.pipelineStepNoteRepository.Create(this.DALPipelineStepNoteMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLPipelineStepNoteMapper.MapBOToModel(this.DALPipelineStepNoteMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStepNoteRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepNoteModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLPipelineStepNoteMapper.MapModelToBO(id, model);
				await this.pipelineStepNoteRepository.Update(this.DALPipelineStepNoteMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepNoteModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineStepNoteRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9c1a0353611c63c98d2f5360de90d41e</Hash>
</Codenesium>*/