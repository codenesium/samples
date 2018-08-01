using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractWorkerPoolService : AbstractService
	{
		private IWorkerPoolRepository workerPoolRepository;

		private IApiWorkerPoolRequestModelValidator workerPoolModelValidator;

		private IBOLWorkerPoolMapper bolWorkerPoolMapper;

		private IDALWorkerPoolMapper dalWorkerPoolMapper;

		private ILogger logger;

		public AbstractWorkerPoolService(
			ILogger logger,
			IWorkerPoolRepository workerPoolRepository,
			IApiWorkerPoolRequestModelValidator workerPoolModelValidator,
			IBOLWorkerPoolMapper bolWorkerPoolMapper,
			IDALWorkerPoolMapper dalWorkerPoolMapper)
			: base()
		{
			this.workerPoolRepository = workerPoolRepository;
			this.workerPoolModelValidator = workerPoolModelValidator;
			this.bolWorkerPoolMapper = bolWorkerPoolMapper;
			this.dalWorkerPoolMapper = dalWorkerPoolMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkerPoolResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.workerPoolRepository.All(limit, offset);

			return this.bolWorkerPoolMapper.MapBOToModel(this.dalWorkerPoolMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiWorkerPoolResponseModel> Get(string id)
		{
			var record = await this.workerPoolRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolWorkerPoolMapper.MapBOToModel(this.dalWorkerPoolMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiWorkerPoolResponseModel>> Create(
			ApiWorkerPoolRequestModel model)
		{
			CreateResponse<ApiWorkerPoolResponseModel> response = new CreateResponse<ApiWorkerPoolResponseModel>(await this.workerPoolModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolWorkerPoolMapper.MapModelToBO(default(string), model);
				var record = await this.workerPoolRepository.Create(this.dalWorkerPoolMapper.MapBOToEF(bo));

				response.SetRecord(this.bolWorkerPoolMapper.MapBOToModel(this.dalWorkerPoolMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiWorkerPoolResponseModel>> Update(
			string id,
			ApiWorkerPoolRequestModel model)
		{
			var validationResult = await this.workerPoolModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolWorkerPoolMapper.MapModelToBO(id, model);
				await this.workerPoolRepository.Update(this.dalWorkerPoolMapper.MapBOToEF(bo));

				var record = await this.workerPoolRepository.Get(id);

				return new UpdateResponse<ApiWorkerPoolResponseModel>(this.bolWorkerPoolMapper.MapBOToModel(this.dalWorkerPoolMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiWorkerPoolResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.workerPoolModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.workerPoolRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiWorkerPoolResponseModel> ByName(string name)
		{
			WorkerPool record = await this.workerPoolRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolWorkerPoolMapper.MapBOToModel(this.dalWorkerPoolMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>fff4133f26887c7f1a03e29b7ccbce39</Hash>
</Codenesium>*/