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
	public abstract class AbstractWorkerService : AbstractService
	{
		protected IWorkerRepository WorkerRepository { get; private set; }

		protected IApiWorkerRequestModelValidator WorkerModelValidator { get; private set; }

		protected IBOLWorkerMapper BolWorkerMapper { get; private set; }

		protected IDALWorkerMapper DalWorkerMapper { get; private set; }

		private ILogger logger;

		public AbstractWorkerService(
			ILogger logger,
			IWorkerRepository workerRepository,
			IApiWorkerRequestModelValidator workerModelValidator,
			IBOLWorkerMapper bolWorkerMapper,
			IDALWorkerMapper dalWorkerMapper)
			: base()
		{
			this.WorkerRepository = workerRepository;
			this.WorkerModelValidator = workerModelValidator;
			this.BolWorkerMapper = bolWorkerMapper;
			this.DalWorkerMapper = dalWorkerMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.WorkerRepository.All(limit, offset);

			return this.BolWorkerMapper.MapBOToModel(this.DalWorkerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiWorkerResponseModel> Get(string id)
		{
			var record = await this.WorkerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolWorkerMapper.MapBOToModel(this.DalWorkerMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiWorkerResponseModel>> Create(
			ApiWorkerRequestModel model)
		{
			CreateResponse<ApiWorkerResponseModel> response = new CreateResponse<ApiWorkerResponseModel>(await this.WorkerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolWorkerMapper.MapModelToBO(default(string), model);
				var record = await this.WorkerRepository.Create(this.DalWorkerMapper.MapBOToEF(bo));

				response.SetRecord(this.BolWorkerMapper.MapBOToModel(this.DalWorkerMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiWorkerResponseModel>> Update(
			string id,
			ApiWorkerRequestModel model)
		{
			var validationResult = await this.WorkerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolWorkerMapper.MapModelToBO(id, model);
				await this.WorkerRepository.Update(this.DalWorkerMapper.MapBOToEF(bo));

				var record = await this.WorkerRepository.Get(id);

				return new UpdateResponse<ApiWorkerResponseModel>(this.BolWorkerMapper.MapBOToModel(this.DalWorkerMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiWorkerResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.WorkerModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.WorkerRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiWorkerResponseModel> ByName(string name)
		{
			Worker record = await this.WorkerRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolWorkerMapper.MapBOToModel(this.DalWorkerMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiWorkerResponseModel>> ByMachinePolicyId(string machinePolicyId, int limit = 0, int offset = int.MaxValue)
		{
			List<Worker> records = await this.WorkerRepository.ByMachinePolicyId(machinePolicyId, limit, offset);

			return this.BolWorkerMapper.MapBOToModel(this.DalWorkerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>cb807e291fb08d716a6e85ac24a6fc8b</Hash>
</Codenesium>*/