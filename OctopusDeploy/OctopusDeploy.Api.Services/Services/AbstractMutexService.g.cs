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
	public abstract class AbstractMutexService : AbstractService
	{
		protected IMutexRepository MutexRepository { get; private set; }

		protected IApiMutexRequestModelValidator MutexModelValidator { get; private set; }

		protected IBOLMutexMapper BolMutexMapper { get; private set; }

		protected IDALMutexMapper DalMutexMapper { get; private set; }

		private ILogger logger;

		public AbstractMutexService(
			ILogger logger,
			IMutexRepository mutexRepository,
			IApiMutexRequestModelValidator mutexModelValidator,
			IBOLMutexMapper bolMutexMapper,
			IDALMutexMapper dalMutexMapper)
			: base()
		{
			this.MutexRepository = mutexRepository;
			this.MutexModelValidator = mutexModelValidator;
			this.BolMutexMapper = bolMutexMapper;
			this.DalMutexMapper = dalMutexMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiMutexResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.MutexRepository.All(limit, offset);

			return this.BolMutexMapper.MapBOToModel(this.DalMutexMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMutexResponseModel> Get(string id)
		{
			var record = await this.MutexRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolMutexMapper.MapBOToModel(this.DalMutexMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiMutexResponseModel>> Create(
			ApiMutexRequestModel model)
		{
			CreateResponse<ApiMutexResponseModel> response = new CreateResponse<ApiMutexResponseModel>(await this.MutexModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolMutexMapper.MapModelToBO(default(string), model);
				var record = await this.MutexRepository.Create(this.DalMutexMapper.MapBOToEF(bo));

				response.SetRecord(this.BolMutexMapper.MapBOToModel(this.DalMutexMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMutexResponseModel>> Update(
			string id,
			ApiMutexRequestModel model)
		{
			var validationResult = await this.MutexModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolMutexMapper.MapModelToBO(id, model);
				await this.MutexRepository.Update(this.DalMutexMapper.MapBOToEF(bo));

				var record = await this.MutexRepository.Get(id);

				return new UpdateResponse<ApiMutexResponseModel>(this.BolMutexMapper.MapBOToModel(this.DalMutexMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiMutexResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.MutexModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.MutexRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cb92912927caeb5ac64c2c778a24848e</Hash>
</Codenesium>*/