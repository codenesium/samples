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
	public abstract class AbstractPipelineStatusService: AbstractService
	{
		private IPipelineStatusRepository pipelineStatusRepository;
		private IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator;
		private IBOLPipelineStatusMapper bolPipelineStatusMapper;
		private IDALPipelineStatusMapper dalPipelineStatusMapper;
		private ILogger logger;

		public AbstractPipelineStatusService(
			ILogger logger,
			IPipelineStatusRepository pipelineStatusRepository,
			IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator,
			IBOLPipelineStatusMapper bolpipelineStatusMapper,
			IDALPipelineStatusMapper dalpipelineStatusMapper)
			: base()

		{
			this.pipelineStatusRepository = pipelineStatusRepository;
			this.pipelineStatusModelValidator = pipelineStatusModelValidator;
			this.bolPipelineStatusMapper = bolpipelineStatusMapper;
			this.dalPipelineStatusMapper = dalpipelineStatusMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineStatusRepository.All(skip, take, orderClause);

			return this.bolPipelineStatusMapper.MapBOToModel(this.dalPipelineStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStatusResponseModel> Get(int id)
		{
			var record = await pipelineStatusRepository.Get(id);

			return this.bolPipelineStatusMapper.MapBOToModel(this.dalPipelineStatusMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPipelineStatusResponseModel>> Create(
			ApiPipelineStatusRequestModel model)
		{
			CreateResponse<ApiPipelineStatusResponseModel> response = new CreateResponse<ApiPipelineStatusResponseModel>(await this.pipelineStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolPipelineStatusMapper.MapModelToBO(default (int), model);
				var record = await this.pipelineStatusRepository.Create(this.dalPipelineStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.bolPipelineStatusMapper.MapBOToModel(this.dalPipelineStatusMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStatusRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.bolPipelineStatusMapper.MapModelToBO(id, model);
				await this.pipelineStatusRepository.Update(this.dalPipelineStatusMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineStatusRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b1b87a124636c89d0b51e43fb1072131</Hash>
</Codenesium>*/