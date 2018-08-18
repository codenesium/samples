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
	public abstract class AbstractDeploymentProcessService : AbstractService
	{
		protected IDeploymentProcessRepository DeploymentProcessRepository { get; private set; }

		protected IApiDeploymentProcessRequestModelValidator DeploymentProcessModelValidator { get; private set; }

		protected IBOLDeploymentProcessMapper BolDeploymentProcessMapper { get; private set; }

		protected IDALDeploymentProcessMapper DalDeploymentProcessMapper { get; private set; }

		private ILogger logger;

		public AbstractDeploymentProcessService(
			ILogger logger,
			IDeploymentProcessRepository deploymentProcessRepository,
			IApiDeploymentProcessRequestModelValidator deploymentProcessModelValidator,
			IBOLDeploymentProcessMapper bolDeploymentProcessMapper,
			IDALDeploymentProcessMapper dalDeploymentProcessMapper)
			: base()
		{
			this.DeploymentProcessRepository = deploymentProcessRepository;
			this.DeploymentProcessModelValidator = deploymentProcessModelValidator;
			this.BolDeploymentProcessMapper = bolDeploymentProcessMapper;
			this.DalDeploymentProcessMapper = dalDeploymentProcessMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeploymentProcessResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DeploymentProcessRepository.All(limit, offset);

			return this.BolDeploymentProcessMapper.MapBOToModel(this.DalDeploymentProcessMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeploymentProcessResponseModel> Get(string id)
		{
			var record = await this.DeploymentProcessRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDeploymentProcessMapper.MapBOToModel(this.DalDeploymentProcessMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDeploymentProcessResponseModel>> Create(
			ApiDeploymentProcessRequestModel model)
		{
			CreateResponse<ApiDeploymentProcessResponseModel> response = new CreateResponse<ApiDeploymentProcessResponseModel>(await this.DeploymentProcessModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDeploymentProcessMapper.MapModelToBO(default(string), model);
				var record = await this.DeploymentProcessRepository.Create(this.DalDeploymentProcessMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDeploymentProcessMapper.MapBOToModel(this.DalDeploymentProcessMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDeploymentProcessResponseModel>> Update(
			string id,
			ApiDeploymentProcessRequestModel model)
		{
			var validationResult = await this.DeploymentProcessModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDeploymentProcessMapper.MapModelToBO(id, model);
				await this.DeploymentProcessRepository.Update(this.DalDeploymentProcessMapper.MapBOToEF(bo));

				var record = await this.DeploymentProcessRepository.Get(id);

				return new UpdateResponse<ApiDeploymentProcessResponseModel>(this.BolDeploymentProcessMapper.MapBOToModel(this.DalDeploymentProcessMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDeploymentProcessResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.DeploymentProcessModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.DeploymentProcessRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>75e014a6eee97668b2c62624d085770e</Hash>
</Codenesium>*/