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
		protected IWorkerPoolRepository WorkerPoolRepository { get; private set; }

		protected IApiWorkerPoolRequestModelValidator WorkerPoolModelValidator { get; private set; }

		protected IBOLWorkerPoolMapper BolWorkerPoolMapper { get; private set; }

		protected IDALWorkerPoolMapper DalWorkerPoolMapper { get; private set; }

		private ILogger logger;

		public AbstractWorkerPoolService(
			ILogger logger,
			IWorkerPoolRepository workerPoolRepository,
			IApiWorkerPoolRequestModelValidator workerPoolModelValidator,
			IBOLWorkerPoolMapper bolWorkerPoolMapper,
			IDALWorkerPoolMapper dalWorkerPoolMapper)
			: base()
		{
			this.WorkerPoolRepository = workerPoolRepository;
			this.WorkerPoolModelValidator = workerPoolModelValidator;
			this.BolWorkerPoolMapper = bolWorkerPoolMapper;
			this.DalWorkerPoolMapper = dalWorkerPoolMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkerPoolResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.WorkerPoolRepository.All(limit, offset);

			return this.BolWorkerPoolMapper.MapBOToModel(this.DalWorkerPoolMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiWorkerPoolResponseModel> Get(string id)
		{
			var record = await this.WorkerPoolRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolWorkerPoolMapper.MapBOToModel(this.DalWorkerPoolMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiWorkerPoolResponseModel>> Create(
			ApiWorkerPoolRequestModel model)
		{
			CreateResponse<ApiWorkerPoolResponseModel> response = new CreateResponse<ApiWorkerPoolResponseModel>(await this.WorkerPoolModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolWorkerPoolMapper.MapModelToBO(default(string), model);
				var record = await this.WorkerPoolRepository.Create(this.DalWorkerPoolMapper.MapBOToEF(bo));

				response.SetRecord(this.BolWorkerPoolMapper.MapBOToModel(this.DalWorkerPoolMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiWorkerPoolResponseModel>> Update(
			string id,
			ApiWorkerPoolRequestModel model)
		{
			var validationResult = await this.WorkerPoolModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolWorkerPoolMapper.MapModelToBO(id, model);
				await this.WorkerPoolRepository.Update(this.DalWorkerPoolMapper.MapBOToEF(bo));

				var record = await this.WorkerPoolRepository.Get(id);

				return new UpdateResponse<ApiWorkerPoolResponseModel>(this.BolWorkerPoolMapper.MapBOToModel(this.DalWorkerPoolMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiWorkerPoolResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.WorkerPoolModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.WorkerPoolRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiWorkerPoolResponseModel> ByName(string name)
		{
			WorkerPool record = await this.WorkerPoolRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolWorkerPoolMapper.MapBOToModel(this.DalWorkerPoolMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>ff6ded3a61d5dd788ffa4efe3c1cabd1</Hash>
</Codenesium>*/