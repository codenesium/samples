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
			IApiPipelineStepRequestModelValidator pipelineStepModelValidator,
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

		public async virtual Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineSteps(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<HandlerPipelineStep> records = await this.PipelineStepRepository.HandlerPipelineSteps(pipelineStepId, limit, offset);

			return this.BolHandlerPipelineStepMapper.MapBOToModel(this.DalHandlerPipelineStepMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiOtherTransportResponseModel>> OtherTransports(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<OtherTransport> records = await this.PipelineStepRepository.OtherTransports(pipelineStepId, limit, offset);

			return this.BolOtherTransportMapper.MapBOToModel(this.DalOtherTransportMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinations(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepDestination> records = await this.PipelineStepRepository.PipelineStepDestinations(pipelineStepId, limit, offset);

			return this.BolPipelineStepDestinationMapper.MapBOToModel(this.DalPipelineStepDestinationMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotes(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepNote> records = await this.PipelineStepRepository.PipelineStepNotes(pipelineStepId, limit, offset);

			return this.BolPipelineStepNoteMapper.MapBOToModel(this.DalPipelineStepNoteMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirements(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepStepRequirement> records = await this.PipelineStepRepository.PipelineStepStepRequirements(pipelineStepId, limit, offset);

			return this.BolPipelineStepStepRequirementMapper.MapBOToModel(this.DalPipelineStepStepRequirementMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>52dbcc3ec2ecb99e5676dea7e8cbc7a9</Hash>
</Codenesium>*/