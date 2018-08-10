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
	public abstract class AbstractHandlerService : AbstractService
	{
		protected IHandlerRepository HandlerRepository { get; private set; }

		protected IApiHandlerRequestModelValidator HandlerModelValidator { get; private set; }

		protected IBOLHandlerMapper BolHandlerMapper { get; private set; }

		protected IDALHandlerMapper DalHandlerMapper { get; private set; }

		protected IBOLAirTransportMapper BolAirTransportMapper { get; private set; }

		protected IDALAirTransportMapper DalAirTransportMapper { get; private set; }
		protected IBOLHandlerPipelineStepMapper BolHandlerPipelineStepMapper { get; private set; }

		protected IDALHandlerPipelineStepMapper DalHandlerPipelineStepMapper { get; private set; }
		protected IBOLOtherTransportMapper BolOtherTransportMapper { get; private set; }

		protected IDALOtherTransportMapper DalOtherTransportMapper { get; private set; }

		private ILogger logger;

		public AbstractHandlerService(
			ILogger logger,
			IHandlerRepository handlerRepository,
			IApiHandlerRequestModelValidator handlerModelValidator,
			IBOLHandlerMapper bolHandlerMapper,
			IDALHandlerMapper dalHandlerMapper,
			IBOLAirTransportMapper bolAirTransportMapper,
			IDALAirTransportMapper dalAirTransportMapper,
			IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper,
			IBOLOtherTransportMapper bolOtherTransportMapper,
			IDALOtherTransportMapper dalOtherTransportMapper)
			: base()
		{
			this.HandlerRepository = handlerRepository;
			this.HandlerModelValidator = handlerModelValidator;
			this.BolHandlerMapper = bolHandlerMapper;
			this.DalHandlerMapper = dalHandlerMapper;
			this.BolAirTransportMapper = bolAirTransportMapper;
			this.DalAirTransportMapper = dalAirTransportMapper;
			this.BolHandlerPipelineStepMapper = bolHandlerPipelineStepMapper;
			this.DalHandlerPipelineStepMapper = dalHandlerPipelineStepMapper;
			this.BolOtherTransportMapper = bolOtherTransportMapper;
			this.DalOtherTransportMapper = dalOtherTransportMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiHandlerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.HandlerRepository.All(limit, offset);

			return this.BolHandlerMapper.MapBOToModel(this.DalHandlerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiHandlerResponseModel> Get(int id)
		{
			var record = await this.HandlerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolHandlerMapper.MapBOToModel(this.DalHandlerMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiHandlerResponseModel>> Create(
			ApiHandlerRequestModel model)
		{
			CreateResponse<ApiHandlerResponseModel> response = new CreateResponse<ApiHandlerResponseModel>(await this.HandlerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolHandlerMapper.MapModelToBO(default(int), model);
				var record = await this.HandlerRepository.Create(this.DalHandlerMapper.MapBOToEF(bo));

				response.SetRecord(this.BolHandlerMapper.MapBOToModel(this.DalHandlerMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiHandlerResponseModel>> Update(
			int id,
			ApiHandlerRequestModel model)
		{
			var validationResult = await this.HandlerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolHandlerMapper.MapModelToBO(id, model);
				await this.HandlerRepository.Update(this.DalHandlerMapper.MapBOToEF(bo));

				var record = await this.HandlerRepository.Get(id);

				return new UpdateResponse<ApiHandlerResponseModel>(this.BolHandlerMapper.MapBOToModel(this.DalHandlerMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiHandlerResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.HandlerModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.HandlerRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiAirTransportResponseModel>> AirTransports(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			List<AirTransport> records = await this.HandlerRepository.AirTransports(handlerId, limit, offset);

			return this.BolAirTransportMapper.MapBOToModel(this.DalAirTransportMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineSteps(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			List<HandlerPipelineStep> records = await this.HandlerRepository.HandlerPipelineSteps(handlerId, limit, offset);

			return this.BolHandlerPipelineStepMapper.MapBOToModel(this.DalHandlerPipelineStepMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiOtherTransportResponseModel>> OtherTransports(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			List<OtherTransport> records = await this.HandlerRepository.OtherTransports(handlerId, limit, offset);

			return this.BolOtherTransportMapper.MapBOToModel(this.DalOtherTransportMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>edefaa8ca2de3056d32b81b9523223a6</Hash>
</Codenesium>*/