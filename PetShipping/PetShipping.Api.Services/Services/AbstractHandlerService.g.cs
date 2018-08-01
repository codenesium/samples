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
		private IHandlerRepository handlerRepository;

		private IApiHandlerRequestModelValidator handlerModelValidator;

		private IBOLHandlerMapper bolHandlerMapper;

		private IDALHandlerMapper dalHandlerMapper;

		private IBOLAirTransportMapper bolAirTransportMapper;

		private IDALAirTransportMapper dalAirTransportMapper;
		private IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper;

		private IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper;
		private IBOLOtherTransportMapper bolOtherTransportMapper;

		private IDALOtherTransportMapper dalOtherTransportMapper;

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
			this.handlerRepository = handlerRepository;
			this.handlerModelValidator = handlerModelValidator;
			this.bolHandlerMapper = bolHandlerMapper;
			this.dalHandlerMapper = dalHandlerMapper;
			this.bolAirTransportMapper = bolAirTransportMapper;
			this.dalAirTransportMapper = dalAirTransportMapper;
			this.bolHandlerPipelineStepMapper = bolHandlerPipelineStepMapper;
			this.dalHandlerPipelineStepMapper = dalHandlerPipelineStepMapper;
			this.bolOtherTransportMapper = bolOtherTransportMapper;
			this.dalOtherTransportMapper = dalOtherTransportMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiHandlerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.handlerRepository.All(limit, offset);

			return this.bolHandlerMapper.MapBOToModel(this.dalHandlerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiHandlerResponseModel> Get(int id)
		{
			var record = await this.handlerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolHandlerMapper.MapBOToModel(this.dalHandlerMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiHandlerResponseModel>> Create(
			ApiHandlerRequestModel model)
		{
			CreateResponse<ApiHandlerResponseModel> response = new CreateResponse<ApiHandlerResponseModel>(await this.handlerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolHandlerMapper.MapModelToBO(default(int), model);
				var record = await this.handlerRepository.Create(this.dalHandlerMapper.MapBOToEF(bo));

				response.SetRecord(this.bolHandlerMapper.MapBOToModel(this.dalHandlerMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiHandlerResponseModel>> Update(
			int id,
			ApiHandlerRequestModel model)
		{
			var validationResult = await this.handlerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolHandlerMapper.MapModelToBO(id, model);
				await this.handlerRepository.Update(this.dalHandlerMapper.MapBOToEF(bo));

				var record = await this.handlerRepository.Get(id);

				return new UpdateResponse<ApiHandlerResponseModel>(this.bolHandlerMapper.MapBOToModel(this.dalHandlerMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiHandlerResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.handlerModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.handlerRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiAirTransportResponseModel>> AirTransports(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			List<AirTransport> records = await this.handlerRepository.AirTransports(handlerId, limit, offset);

			return this.bolAirTransportMapper.MapBOToModel(this.dalAirTransportMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineSteps(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			List<HandlerPipelineStep> records = await this.handlerRepository.HandlerPipelineSteps(handlerId, limit, offset);

			return this.bolHandlerPipelineStepMapper.MapBOToModel(this.dalHandlerPipelineStepMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiOtherTransportResponseModel>> OtherTransports(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			List<OtherTransport> records = await this.handlerRepository.OtherTransports(handlerId, limit, offset);

			return this.bolOtherTransportMapper.MapBOToModel(this.dalOtherTransportMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>5a20f536b346e6ca1068f8a45ac91a6a</Hash>
</Codenesium>*/