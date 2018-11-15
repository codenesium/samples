using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStepService : AbstractService
	{
		protected IPipelineStepRepository PipelineStepRepository { get; private set; }

		protected IApiPipelineStepServerRequestModelValidator PipelineStepModelValidator { get; private set; }

		protected IBOLPipelineStepMapper BolPipelineStepMapper { get; private set; }

		protected IDALPipelineStepMapper DalPipelineStepMapper { get; private set; }

		protected IBOLHandlerPipelineStepMapper BolHandlerPipelineStepMapper { get; private set; }

		protected IDALHandlerPipelineStepMapper DalHandlerPipelineStepMapper { get; private set; }

		protected IBOLOtherTransportMapper BolOtherTransportMapper { get; private set; }

		protected IDALOtherTransportMapper DalOtherTransportMapper { get; private set; }

		protected IBOLPipelineStepDestinationMapper BolPipelineStepDestinationMapper { get; private set; }

		protected IDALPipelineStepDestinationMapper DalPipelineStepDestinationMapper { get; private set; }

		protected IBOLPipelineStepNoteMapper BolPipelineStepNoteMapper { get; private set; }

		protected IDALPipelineStepNoteMapper DalPipelineStepNoteMapper { get; private set; }

		protected IBOLPipelineStepStepRequirementMapper BolPipelineStepStepRequirementMapper { get; private set; }

		protected IDALPipelineStepStepRequirementMapper DalPipelineStepStepRequirementMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepService(
			ILogger logger,
			IPipelineStepRepository pipelineStepRepository,
			IApiPipelineStepServerRequestModelValidator pipelineStepModelValidator,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper,
			IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper,
			IBOLOtherTransportMapper bolOtherTransportMapper,
			IDALOtherTransportMapper dalOtherTransportMapper,
			IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper,
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
			this.BolHandlerPipelineStepMapper = bolHandlerPipelineStepMapper;
			this.DalHandlerPipelineStepMapper = dalHandlerPipelineStepMapper;
			this.BolOtherTransportMapper = bolOtherTransportMapper;
			this.DalOtherTransportMapper = dalOtherTransportMapper;
			this.BolPipelineStepDestinationMapper = bolPipelineStepDestinationMapper;
			this.DalPipelineStepDestinationMapper = dalPipelineStepDestinationMapper;
			this.BolPipelineStepNoteMapper = bolPipelineStepNoteMapper;
			this.DalPipelineStepNoteMapper = dalPipelineStepNoteMapper;
			this.BolPipelineStepStepRequirementMapper = bolPipelineStepStepRequirementMapper;
			this.DalPipelineStepStepRequirementMapper = dalPipelineStepStepRequirementMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineStepRepository.All(limit, offset);

			return this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStepServerResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiPipelineStepServerResponseModel>> Create(
			ApiPipelineStepServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepServerResponseModel> response = ValidationResponseFactory<ApiPipelineStepServerResponseModel>.CreateResponse(await this.PipelineStepModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPipelineStepMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineStepRepository.Create(this.DalPipelineStepMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepServerResponseModel>> Update(
			int id,
			ApiPipelineStepServerRequestModel model)
		{
			var validationResult = await this.PipelineStepModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineStepMapper.MapModelToBO(id, model);
				await this.PipelineStepRepository.Update(this.DalPipelineStepMapper.MapBOToEF(bo));

				var record = await this.PipelineStepRepository.Get(id);

				return ValidationResponseFactory<ApiPipelineStepServerResponseModel>.UpdateResponse(this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineStepServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineStepModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineStepRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiHandlerPipelineStepServerResponseModel>> HandlerPipelineStepsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<HandlerPipelineStep> records = await this.PipelineStepRepository.HandlerPipelineStepsByPipelineStepId(pipelineStepId, limit, offset);

			return this.BolHandlerPipelineStepMapper.MapBOToModel(this.DalHandlerPipelineStepMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiOtherTransportServerResponseModel>> OtherTransportsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<OtherTransport> records = await this.PipelineStepRepository.OtherTransportsByPipelineStepId(pipelineStepId, limit, offset);

			return this.BolOtherTransportMapper.MapBOToModel(this.DalOtherTransportMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepDestinationServerResponseModel>> PipelineStepDestinationsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepDestination> records = await this.PipelineStepRepository.PipelineStepDestinationsByPipelineStepId(pipelineStepId, limit, offset);

			return this.BolPipelineStepDestinationMapper.MapBOToModel(this.DalPipelineStepDestinationMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepNoteServerResponseModel>> PipelineStepNotesByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepNote> records = await this.PipelineStepRepository.PipelineStepNotesByPipelineStepId(pipelineStepId, limit, offset);

			return this.BolPipelineStepNoteMapper.MapBOToModel(this.DalPipelineStepNoteMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepStepRequirementServerResponseModel>> PipelineStepStepRequirementsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepStepRequirement> records = await this.PipelineStepRepository.PipelineStepStepRequirementsByPipelineStepId(pipelineStepId, limit, offset);

			return this.BolPipelineStepStepRequirementMapper.MapBOToModel(this.DalPipelineStepStepRequirementMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>292d3c6a568d5a71b4f2600f02715d94</Hash>
</Codenesium>*/