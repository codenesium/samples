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
	public abstract class AbstractPipelineStepService : AbstractService
	{
		protected IPipelineStepRepository PipelineStepRepository { get; private set; }

		protected IApiPipelineStepRequestModelValidator PipelineStepModelValidator { get; private set; }

		protected IBOLPipelineStepMapper BolPipelineStepMapper { get; private set; }

		protected IDALPipelineStepMapper DalPipelineStepMapper { get; private set; }

		protected IBOLPipelineStepNoteMapper BolPipelineStepNoteMapper { get; private set; }

		protected IDALPipelineStepNoteMapper DalPipelineStepNoteMapper { get; private set; }

		protected IBOLPipelineStepStepRequirementMapper BolPipelineStepStepRequirementMapper { get; private set; }

		protected IDALPipelineStepStepRequirementMapper DalPipelineStepStepRequirementMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepService(
			ILogger logger,
			IPipelineStepRepository pipelineStepRepository,
			IApiPipelineStepRequestModelValidator pipelineStepModelValidator,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper,
			IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper,
			IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper,
			IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper)
			: base()
		{
			this.PipelineStepRepository = pipelineStepRepository;
			this.PipelineStepModelValidator = pipelineStepModelValidator;
			this.BolPipelineStepMapper = bolPipelineStepMapper;
			this.DalPipelineStepMapper = dalPipelineStepMapper;
			this.BolPipelineStepNoteMapper = bolPipelineStepNoteMapper;
			this.DalPipelineStepNoteMapper = dalPipelineStepNoteMapper;
			this.BolPipelineStepStepRequirementMapper = bolPipelineStepStepRequirementMapper;
			this.DalPipelineStepStepRequirementMapper = dalPipelineStepStepRequirementMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineStepRepository.All(limit, offset);

			return this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStepResponseModel> Get(int id)
		{
			var record = await this.PipelineStepRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepResponseModel>> Create(
			ApiPipelineStepRequestModel model)
		{
			CreateResponse<ApiPipelineStepResponseModel> response = new CreateResponse<ApiPipelineStepResponseModel>(await this.PipelineStepModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPipelineStepMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineStepRepository.Create(this.DalPipelineStepMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepResponseModel>> Update(
			int id,
			ApiPipelineStepRequestModel model)
		{
			var validationResult = await this.PipelineStepModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineStepMapper.MapModelToBO(id, model);
				await this.PipelineStepRepository.Update(this.DalPipelineStepMapper.MapBOToEF(bo));

				var record = await this.PipelineStepRepository.Get(id);

				return new UpdateResponse<ApiPipelineStepResponseModel>(this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPipelineStepResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PipelineStepModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PipelineStepRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotesByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepNote> records = await this.PipelineStepRepository.PipelineStepNotesByPipelineStepId(pipelineStepId, limit, offset);

			return this.BolPipelineStepNoteMapper.MapBOToModel(this.DalPipelineStepNoteMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirementsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepStepRequirement> records = await this.PipelineStepRepository.PipelineStepStepRequirementsByPipelineStepId(pipelineStepId, limit, offset);

			return this.BolPipelineStepStepRequirementMapper.MapBOToModel(this.DalPipelineStepStepRequirementMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepResponseModel>> ByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStep> records = await this.PipelineStepRepository.ByPipelineStepId(pipelineStepId, limit, offset);

			return this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>2768e8a6da0255cab5b8922f4e766be7</Hash>
</Codenesium>*/