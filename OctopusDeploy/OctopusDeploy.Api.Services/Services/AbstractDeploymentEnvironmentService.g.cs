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
	public abstract class AbstractDeploymentEnvironmentService : AbstractService
	{
		protected IDeploymentEnvironmentRepository DeploymentEnvironmentRepository { get; private set; }

		protected IApiDeploymentEnvironmentRequestModelValidator DeploymentEnvironmentModelValidator { get; private set; }

		protected IBOLDeploymentEnvironmentMapper BolDeploymentEnvironmentMapper { get; private set; }

		protected IDALDeploymentEnvironmentMapper DalDeploymentEnvironmentMapper { get; private set; }

		private ILogger logger;

		public AbstractDeploymentEnvironmentService(
			ILogger logger,
			IDeploymentEnvironmentRepository deploymentEnvironmentRepository,
			IApiDeploymentEnvironmentRequestModelValidator deploymentEnvironmentModelValidator,
			IBOLDeploymentEnvironmentMapper bolDeploymentEnvironmentMapper,
			IDALDeploymentEnvironmentMapper dalDeploymentEnvironmentMapper)
			: base()
		{
			this.DeploymentEnvironmentRepository = deploymentEnvironmentRepository;
			this.DeploymentEnvironmentModelValidator = deploymentEnvironmentModelValidator;
			this.BolDeploymentEnvironmentMapper = bolDeploymentEnvironmentMapper;
			this.DalDeploymentEnvironmentMapper = dalDeploymentEnvironmentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeploymentEnvironmentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DeploymentEnvironmentRepository.All(limit, offset);

			return this.BolDeploymentEnvironmentMapper.MapBOToModel(this.DalDeploymentEnvironmentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeploymentEnvironmentResponseModel> Get(string id)
		{
			var record = await this.DeploymentEnvironmentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDeploymentEnvironmentMapper.MapBOToModel(this.DalDeploymentEnvironmentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDeploymentEnvironmentResponseModel>> Create(
			ApiDeploymentEnvironmentRequestModel model)
		{
			CreateResponse<ApiDeploymentEnvironmentResponseModel> response = new CreateResponse<ApiDeploymentEnvironmentResponseModel>(await this.DeploymentEnvironmentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDeploymentEnvironmentMapper.MapModelToBO(default(string), model);
				var record = await this.DeploymentEnvironmentRepository.Create(this.DalDeploymentEnvironmentMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDeploymentEnvironmentMapper.MapBOToModel(this.DalDeploymentEnvironmentMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDeploymentEnvironmentResponseModel>> Update(
			string id,
			ApiDeploymentEnvironmentRequestModel model)
		{
			var validationResult = await this.DeploymentEnvironmentModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDeploymentEnvironmentMapper.MapModelToBO(id, model);
				await this.DeploymentEnvironmentRepository.Update(this.DalDeploymentEnvironmentMapper.MapBOToEF(bo));

				var record = await this.DeploymentEnvironmentRepository.Get(id);

				return new UpdateResponse<ApiDeploymentEnvironmentResponseModel>(this.BolDeploymentEnvironmentMapper.MapBOToModel(this.DalDeploymentEnvironmentMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDeploymentEnvironmentResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.DeploymentEnvironmentModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.DeploymentEnvironmentRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiDeploymentEnvironmentResponseModel> ByName(string name)
		{
			DeploymentEnvironment record = await this.DeploymentEnvironmentRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDeploymentEnvironmentMapper.MapBOToModel(this.DalDeploymentEnvironmentMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiDeploymentEnvironmentResponseModel>> ByDataVersion(byte[] dataVersion, int limit = 0, int offset = int.MaxValue)
		{
			List<DeploymentEnvironment> records = await this.DeploymentEnvironmentRepository.ByDataVersion(dataVersion, limit, offset);

			return this.BolDeploymentEnvironmentMapper.MapBOToModel(this.DalDeploymentEnvironmentMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>325d256406878209e116092ad0554d83</Hash>
</Codenesium>*/