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
		private IWorkerRepository workerRepository;

		private IApiWorkerRequestModelValidator workerModelValidator;

		private IBOLWorkerMapper bolWorkerMapper;

		private IDALWorkerMapper dalWorkerMapper;

		private ILogger logger;

		public AbstractWorkerService(
			ILogger logger,
			IWorkerRepository workerRepository,
			IApiWorkerRequestModelValidator workerModelValidator,
			IBOLWorkerMapper bolWorkerMapper,
			IDALWorkerMapper dalWorkerMapper)
			: base()
		{
			this.workerRepository = workerRepository;
			this.workerModelValidator = workerModelValidator;
			this.bolWorkerMapper = bolWorkerMapper;
			this.dalWorkerMapper = dalWorkerMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.workerRepository.All(limit, offset);

			return this.bolWorkerMapper.MapBOToModel(this.dalWorkerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiWorkerResponseModel> Get(string id)
		{
			var record = await this.workerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolWorkerMapper.MapBOToModel(this.dalWorkerMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiWorkerResponseModel>> Create(
			ApiWorkerRequestModel model)
		{
			CreateResponse<ApiWorkerResponseModel> response = new CreateResponse<ApiWorkerResponseModel>(await this.workerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolWorkerMapper.MapModelToBO(default(string), model);
				var record = await this.workerRepository.Create(this.dalWorkerMapper.MapBOToEF(bo));

				response.SetRecord(this.bolWorkerMapper.MapBOToModel(this.dalWorkerMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiWorkerResponseModel>> Update(
			string id,
			ApiWorkerRequestModel model)
		{
			var validationResult = await this.workerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolWorkerMapper.MapModelToBO(id, model);
				await this.workerRepository.Update(this.dalWorkerMapper.MapBOToEF(bo));

				var record = await this.workerRepository.Get(id);

				return new UpdateResponse<ApiWorkerResponseModel>(this.bolWorkerMapper.MapBOToModel(this.dalWorkerMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiWorkerResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.workerModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.workerRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiWorkerResponseModel> ByName(string name)
		{
			Worker record = await this.workerRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolWorkerMapper.MapBOToModel(this.dalWorkerMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiWorkerResponseModel>> ByMachinePolicyId(string machinePolicyId)
		{
			List<Worker> records = await this.workerRepository.ByMachinePolicyId(machinePolicyId);

			return this.bolWorkerMapper.MapBOToModel(this.dalWorkerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>67f64ef4236122a9b75d5b028257cd77</Hash>
</Codenesium>*/