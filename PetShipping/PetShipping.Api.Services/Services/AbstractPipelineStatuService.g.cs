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
	public abstract class AbstractPipelineStatuService : AbstractService
	{
		protected IPipelineStatuRepository PipelineStatuRepository { get; private set; }

		protected IApiPipelineStatuRequestModelValidator PipelineStatuModelValidator { get; private set; }

		protected IBOLPipelineStatuMapper BolPipelineStatuMapper { get; private set; }

		protected IDALPipelineStatuMapper DalPipelineStatuMapper { get; private set; }

		protected IBOLPipelineMapper BolPipelineMapper { get; private set; }

		protected IDALPipelineMapper DalPipelineMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStatuService(
			ILogger logger,
			IPipelineStatuRepository pipelineStatuRepository,
			IApiPipelineStatuRequestModelValidator pipelineStatuModelValidator,
			IBOLPipelineStatuMapper bolPipelineStatuMapper,
			IDALPipelineStatuMapper dalPipelineStatuMapper,
			IBOLPipelineMapper bolPipelineMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base()
		{
			this.PipelineStatuRepository = pipelineStatuRepository;
			this.PipelineStatuModelValidator = pipelineStatuModelValidator;
			this.BolPipelineStatuMapper = bolPipelineStatuMapper;
			this.DalPipelineStatuMapper = dalPipelineStatuMapper;
			this.BolPipelineMapper = bolPipelineMapper;
			this.DalPipelineMapper = dalPipelineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStatuResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineStatuRepository.All(limit, offset);

			return this.BolPipelineStatuMapper.MapBOToModel(this.DalPipelineStatuMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStatuResponseModel> Get(int id)
		{
			var record = await this.PipelineStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineStatuMapper.MapBOToModel(this.DalPipelineStatuMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStatuResponseModel>> Create(
			ApiPipelineStatuRequestModel model)
		{
			CreateResponse<ApiPipelineStatuResponseModel> response = new CreateResponse<ApiPipelineStatuResponseModel>(await this.PipelineStatuModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPipelineStatuMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineStatuRepository.Create(this.DalPipelineStatuMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineStatuMapper.MapBOToModel(this.DalPipelineStatuMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStatuResponseModel>> Update(
			int id,
			ApiPipelineStatuRequestModel model)
		{
			var validationResult = await this.PipelineStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineStatuMapper.MapModelToBO(id, model);
				await this.PipelineStatuRepository.Update(this.DalPipelineStatuMapper.MapBOToEF(bo));

				var record = await this.PipelineStatuRepository.Get(id);

				return new UpdateResponse<ApiPipelineStatuResponseModel>(this.BolPipelineStatuMapper.MapBOToModel(this.DalPipelineStatuMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPipelineStatuResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PipelineStatuModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PipelineStatuRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiPipelineResponseModel>> PipelinesByPipelineStatusId(int pipelineStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Pipeline> records = await this.PipelineStatuRepository.PipelinesByPipelineStatusId(pipelineStatusId, limit, offset);

			return this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>cdcfcb00a676681e8c54db82ce7608d9</Hash>
</Codenesium>*/