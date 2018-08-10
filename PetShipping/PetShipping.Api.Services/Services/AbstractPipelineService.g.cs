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
	public abstract class AbstractPipelineService : AbstractService
	{
		protected IPipelineRepository PipelineRepository { get; private set; }

		protected IApiPipelineRequestModelValidator PipelineModelValidator { get; private set; }

		protected IBOLPipelineMapper BolPipelineMapper { get; private set; }

		protected IDALPipelineMapper DalPipelineMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineService(
			ILogger logger,
			IPipelineRepository pipelineRepository,
			IApiPipelineRequestModelValidator pipelineModelValidator,
			IBOLPipelineMapper bolPipelineMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base()
		{
			this.PipelineRepository = pipelineRepository;
			this.PipelineModelValidator = pipelineModelValidator;
			this.BolPipelineMapper = bolPipelineMapper;
			this.DalPipelineMapper = dalPipelineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineRepository.All(limit, offset);

			return this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineResponseModel> Get(int id)
		{
			var record = await this.PipelineRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineResponseModel>> Create(
			ApiPipelineRequestModel model)
		{
			CreateResponse<ApiPipelineResponseModel> response = new CreateResponse<ApiPipelineResponseModel>(await this.PipelineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPipelineMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineRepository.Create(this.DalPipelineMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineResponseModel>> Update(
			int id,
			ApiPipelineRequestModel model)
		{
			var validationResult = await this.PipelineModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineMapper.MapModelToBO(id, model);
				await this.PipelineRepository.Update(this.DalPipelineMapper.MapBOToEF(bo));

				var record = await this.PipelineRepository.Get(id);

				return new UpdateResponse<ApiPipelineResponseModel>(this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPipelineResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PipelineModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PipelineRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>73b88cf194f61cef3aa87217ffa105bf</Hash>
</Codenesium>*/