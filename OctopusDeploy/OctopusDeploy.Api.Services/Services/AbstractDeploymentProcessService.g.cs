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
		private IDeploymentProcessRepository deploymentProcessRepository;

		private IApiDeploymentProcessRequestModelValidator deploymentProcessModelValidator;

		private IBOLDeploymentProcessMapper bolDeploymentProcessMapper;

		private IDALDeploymentProcessMapper dalDeploymentProcessMapper;

		private ILogger logger;

		public AbstractDeploymentProcessService(
			ILogger logger,
			IDeploymentProcessRepository deploymentProcessRepository,
			IApiDeploymentProcessRequestModelValidator deploymentProcessModelValidator,
			IBOLDeploymentProcessMapper bolDeploymentProcessMapper,
			IDALDeploymentProcessMapper dalDeploymentProcessMapper)
			: base()
		{
			this.deploymentProcessRepository = deploymentProcessRepository;
			this.deploymentProcessModelValidator = deploymentProcessModelValidator;
			this.bolDeploymentProcessMapper = bolDeploymentProcessMapper;
			this.dalDeploymentProcessMapper = dalDeploymentProcessMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeploymentProcessResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.deploymentProcessRepository.All(limit, offset);

			return this.bolDeploymentProcessMapper.MapBOToModel(this.dalDeploymentProcessMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeploymentProcessResponseModel> Get(string id)
		{
			var record = await this.deploymentProcessRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolDeploymentProcessMapper.MapBOToModel(this.dalDeploymentProcessMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDeploymentProcessResponseModel>> Create(
			ApiDeploymentProcessRequestModel model)
		{
			CreateResponse<ApiDeploymentProcessResponseModel> response = new CreateResponse<ApiDeploymentProcessResponseModel>(await this.deploymentProcessModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolDeploymentProcessMapper.MapModelToBO(default(string), model);
				var record = await this.deploymentProcessRepository.Create(this.dalDeploymentProcessMapper.MapBOToEF(bo));

				response.SetRecord(this.bolDeploymentProcessMapper.MapBOToModel(this.dalDeploymentProcessMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDeploymentProcessResponseModel>> Update(
			string id,
			ApiDeploymentProcessRequestModel model)
		{
			var validationResult = await this.deploymentProcessModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolDeploymentProcessMapper.MapModelToBO(id, model);
				await this.deploymentProcessRepository.Update(this.dalDeploymentProcessMapper.MapBOToEF(bo));

				var record = await this.deploymentProcessRepository.Get(id);

				return new UpdateResponse<ApiDeploymentProcessResponseModel>(this.bolDeploymentProcessMapper.MapBOToModel(this.dalDeploymentProcessMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDeploymentProcessResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.deploymentProcessModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.deploymentProcessRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>47007521570ee674fa0a42507deb2ffd</Hash>
</Codenesium>*/