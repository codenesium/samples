using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStepNoteService : AbstractService
	{
		protected IPipelineStepNoteRepository PipelineStepNoteRepository { get; private set; }

		protected IApiPipelineStepNoteRequestModelValidator PipelineStepNoteModelValidator { get; private set; }

		protected IBOLPipelineStepNoteMapper BolPipelineStepNoteMapper { get; private set; }

		protected IDALPipelineStepNoteMapper DalPipelineStepNoteMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepNoteService(
			ILogger logger,
			IPipelineStepNoteRepository pipelineStepNoteRepository,
			IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator,
			IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper)
			: base()
		{
			this.PipelineStepNoteRepository = pipelineStepNoteRepository;
			this.PipelineStepNoteModelValidator = pipelineStepNoteModelValidator;
			this.BolPipelineStepNoteMapper = bolPipelineStepNoteMapper;
			this.DalPipelineStepNoteMapper = dalPipelineStepNoteMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepNoteResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineStepNoteRepository.All(limit, offset);

			return this.BolPipelineStepNoteMapper.MapBOToModel(this.DalPipelineStepNoteMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStepNoteResponseModel> Get(int id)
		{
			var record = await this.PipelineStepNoteRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineStepNoteMapper.MapBOToModel(this.DalPipelineStepNoteMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepNoteResponseModel>> Create(
			ApiPipelineStepNoteRequestModel model)
		{
			CreateResponse<ApiPipelineStepNoteResponseModel> response = new CreateResponse<ApiPipelineStepNoteResponseModel>(await this.PipelineStepNoteModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPipelineStepNoteMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineStepNoteRepository.Create(this.DalPipelineStepNoteMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineStepNoteMapper.MapBOToModel(this.DalPipelineStepNoteMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepNoteResponseModel>> Update(
			int id,
			ApiPipelineStepNoteRequestModel model)
		{
			var validationResult = await this.PipelineStepNoteModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineStepNoteMapper.MapModelToBO(id, model);
				await this.PipelineStepNoteRepository.Update(this.DalPipelineStepNoteMapper.MapBOToEF(bo));

				var record = await this.PipelineStepNoteRepository.Get(id);

				return new UpdateResponse<ApiPipelineStepNoteResponseModel>(this.BolPipelineStepNoteMapper.MapBOToModel(this.DalPipelineStepNoteMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPipelineStepNoteResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PipelineStepNoteModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PipelineStepNoteRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>75b50a31849c0362dfff1065e535fcd5</Hash>
</Codenesium>*/