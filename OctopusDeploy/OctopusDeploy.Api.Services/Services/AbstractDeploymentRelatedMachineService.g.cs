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
	public abstract class AbstractDeploymentRelatedMachineService : AbstractService
	{
		protected IDeploymentRelatedMachineRepository DeploymentRelatedMachineRepository { get; private set; }

		protected IApiDeploymentRelatedMachineRequestModelValidator DeploymentRelatedMachineModelValidator { get; private set; }

		protected IBOLDeploymentRelatedMachineMapper BolDeploymentRelatedMachineMapper { get; private set; }

		protected IDALDeploymentRelatedMachineMapper DalDeploymentRelatedMachineMapper { get; private set; }

		private ILogger logger;

		public AbstractDeploymentRelatedMachineService(
			ILogger logger,
			IDeploymentRelatedMachineRepository deploymentRelatedMachineRepository,
			IApiDeploymentRelatedMachineRequestModelValidator deploymentRelatedMachineModelValidator,
			IBOLDeploymentRelatedMachineMapper bolDeploymentRelatedMachineMapper,
			IDALDeploymentRelatedMachineMapper dalDeploymentRelatedMachineMapper)
			: base()
		{
			this.DeploymentRelatedMachineRepository = deploymentRelatedMachineRepository;
			this.DeploymentRelatedMachineModelValidator = deploymentRelatedMachineModelValidator;
			this.BolDeploymentRelatedMachineMapper = bolDeploymentRelatedMachineMapper;
			this.DalDeploymentRelatedMachineMapper = dalDeploymentRelatedMachineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeploymentRelatedMachineResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DeploymentRelatedMachineRepository.All(limit, offset);

			return this.BolDeploymentRelatedMachineMapper.MapBOToModel(this.DalDeploymentRelatedMachineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeploymentRelatedMachineResponseModel> Get(int id)
		{
			var record = await this.DeploymentRelatedMachineRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDeploymentRelatedMachineMapper.MapBOToModel(this.DalDeploymentRelatedMachineMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDeploymentRelatedMachineResponseModel>> Create(
			ApiDeploymentRelatedMachineRequestModel model)
		{
			CreateResponse<ApiDeploymentRelatedMachineResponseModel> response = new CreateResponse<ApiDeploymentRelatedMachineResponseModel>(await this.DeploymentRelatedMachineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDeploymentRelatedMachineMapper.MapModelToBO(default(int), model);
				var record = await this.DeploymentRelatedMachineRepository.Create(this.DalDeploymentRelatedMachineMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDeploymentRelatedMachineMapper.MapBOToModel(this.DalDeploymentRelatedMachineMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>> Update(
			int id,
			ApiDeploymentRelatedMachineRequestModel model)
		{
			var validationResult = await this.DeploymentRelatedMachineModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDeploymentRelatedMachineMapper.MapModelToBO(id, model);
				await this.DeploymentRelatedMachineRepository.Update(this.DalDeploymentRelatedMachineMapper.MapBOToEF(bo));

				var record = await this.DeploymentRelatedMachineRepository.Get(id);

				return new UpdateResponse<ApiDeploymentRelatedMachineResponseModel>(this.BolDeploymentRelatedMachineMapper.MapBOToModel(this.DalDeploymentRelatedMachineMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDeploymentRelatedMachineResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.DeploymentRelatedMachineModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.DeploymentRelatedMachineRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiDeploymentRelatedMachineResponseModel>> ByDeploymentId(string deploymentId)
		{
			List<DeploymentRelatedMachine> records = await this.DeploymentRelatedMachineRepository.ByDeploymentId(deploymentId);

			return this.BolDeploymentRelatedMachineMapper.MapBOToModel(this.DalDeploymentRelatedMachineMapper.MapEFToBO(records));
		}

		public async Task<List<ApiDeploymentRelatedMachineResponseModel>> ByMachineId(string machineId)
		{
			List<DeploymentRelatedMachine> records = await this.DeploymentRelatedMachineRepository.ByMachineId(machineId);

			return this.BolDeploymentRelatedMachineMapper.MapBOToModel(this.DalDeploymentRelatedMachineMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>3ffe3f5e4b580241475ef6e0380bec17</Hash>
</Codenesium>*/