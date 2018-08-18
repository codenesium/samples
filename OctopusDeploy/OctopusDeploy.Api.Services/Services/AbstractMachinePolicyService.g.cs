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
	public abstract class AbstractMachinePolicyService : AbstractService
	{
		protected IMachinePolicyRepository MachinePolicyRepository { get; private set; }

		protected IApiMachinePolicyRequestModelValidator MachinePolicyModelValidator { get; private set; }

		protected IBOLMachinePolicyMapper BolMachinePolicyMapper { get; private set; }

		protected IDALMachinePolicyMapper DalMachinePolicyMapper { get; private set; }

		private ILogger logger;

		public AbstractMachinePolicyService(
			ILogger logger,
			IMachinePolicyRepository machinePolicyRepository,
			IApiMachinePolicyRequestModelValidator machinePolicyModelValidator,
			IBOLMachinePolicyMapper bolMachinePolicyMapper,
			IDALMachinePolicyMapper dalMachinePolicyMapper)
			: base()
		{
			this.MachinePolicyRepository = machinePolicyRepository;
			this.MachinePolicyModelValidator = machinePolicyModelValidator;
			this.BolMachinePolicyMapper = bolMachinePolicyMapper;
			this.DalMachinePolicyMapper = dalMachinePolicyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiMachinePolicyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.MachinePolicyRepository.All(limit, offset);

			return this.BolMachinePolicyMapper.MapBOToModel(this.DalMachinePolicyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMachinePolicyResponseModel> Get(string id)
		{
			var record = await this.MachinePolicyRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolMachinePolicyMapper.MapBOToModel(this.DalMachinePolicyMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiMachinePolicyResponseModel>> Create(
			ApiMachinePolicyRequestModel model)
		{
			CreateResponse<ApiMachinePolicyResponseModel> response = new CreateResponse<ApiMachinePolicyResponseModel>(await this.MachinePolicyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolMachinePolicyMapper.MapModelToBO(default(string), model);
				var record = await this.MachinePolicyRepository.Create(this.DalMachinePolicyMapper.MapBOToEF(bo));

				response.SetRecord(this.BolMachinePolicyMapper.MapBOToModel(this.DalMachinePolicyMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMachinePolicyResponseModel>> Update(
			string id,
			ApiMachinePolicyRequestModel model)
		{
			var validationResult = await this.MachinePolicyModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolMachinePolicyMapper.MapModelToBO(id, model);
				await this.MachinePolicyRepository.Update(this.DalMachinePolicyMapper.MapBOToEF(bo));

				var record = await this.MachinePolicyRepository.Get(id);

				return new UpdateResponse<ApiMachinePolicyResponseModel>(this.BolMachinePolicyMapper.MapBOToModel(this.DalMachinePolicyMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiMachinePolicyResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.MachinePolicyModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.MachinePolicyRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiMachinePolicyResponseModel> ByName(string name)
		{
			MachinePolicy record = await this.MachinePolicyRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolMachinePolicyMapper.MapBOToModel(this.DalMachinePolicyMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>428dfe0fe0fb96d0f0f69b52631996db</Hash>
</Codenesium>*/