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
	public abstract class AbstractWorkerTaskLeaseService : AbstractService
	{
		protected IWorkerTaskLeaseRepository WorkerTaskLeaseRepository { get; private set; }

		protected IApiWorkerTaskLeaseRequestModelValidator WorkerTaskLeaseModelValidator { get; private set; }

		protected IBOLWorkerTaskLeaseMapper BolWorkerTaskLeaseMapper { get; private set; }

		protected IDALWorkerTaskLeaseMapper DalWorkerTaskLeaseMapper { get; private set; }

		private ILogger logger;

		public AbstractWorkerTaskLeaseService(
			ILogger logger,
			IWorkerTaskLeaseRepository workerTaskLeaseRepository,
			IApiWorkerTaskLeaseRequestModelValidator workerTaskLeaseModelValidator,
			IBOLWorkerTaskLeaseMapper bolWorkerTaskLeaseMapper,
			IDALWorkerTaskLeaseMapper dalWorkerTaskLeaseMapper)
			: base()
		{
			this.WorkerTaskLeaseRepository = workerTaskLeaseRepository;
			this.WorkerTaskLeaseModelValidator = workerTaskLeaseModelValidator;
			this.BolWorkerTaskLeaseMapper = bolWorkerTaskLeaseMapper;
			this.DalWorkerTaskLeaseMapper = dalWorkerTaskLeaseMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkerTaskLeaseResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.WorkerTaskLeaseRepository.All(limit, offset);

			return this.BolWorkerTaskLeaseMapper.MapBOToModel(this.DalWorkerTaskLeaseMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiWorkerTaskLeaseResponseModel> Get(string id)
		{
			var record = await this.WorkerTaskLeaseRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolWorkerTaskLeaseMapper.MapBOToModel(this.DalWorkerTaskLeaseMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiWorkerTaskLeaseResponseModel>> Create(
			ApiWorkerTaskLeaseRequestModel model)
		{
			CreateResponse<ApiWorkerTaskLeaseResponseModel> response = new CreateResponse<ApiWorkerTaskLeaseResponseModel>(await this.WorkerTaskLeaseModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolWorkerTaskLeaseMapper.MapModelToBO(default(string), model);
				var record = await this.WorkerTaskLeaseRepository.Create(this.DalWorkerTaskLeaseMapper.MapBOToEF(bo));

				response.SetRecord(this.BolWorkerTaskLeaseMapper.MapBOToModel(this.DalWorkerTaskLeaseMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiWorkerTaskLeaseResponseModel>> Update(
			string id,
			ApiWorkerTaskLeaseRequestModel model)
		{
			var validationResult = await this.WorkerTaskLeaseModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolWorkerTaskLeaseMapper.MapModelToBO(id, model);
				await this.WorkerTaskLeaseRepository.Update(this.DalWorkerTaskLeaseMapper.MapBOToEF(bo));

				var record = await this.WorkerTaskLeaseRepository.Get(id);

				return new UpdateResponse<ApiWorkerTaskLeaseResponseModel>(this.BolWorkerTaskLeaseMapper.MapBOToModel(this.DalWorkerTaskLeaseMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiWorkerTaskLeaseResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.WorkerTaskLeaseModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.WorkerTaskLeaseRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>23b2311408405d8427fcdf4b507fb2f6</Hash>
</Codenesium>*/