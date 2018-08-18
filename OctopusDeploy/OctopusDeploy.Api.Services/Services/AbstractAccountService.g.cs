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
	public abstract class AbstractAccountService : AbstractService
	{
		protected IAccountRepository AccountRepository { get; private set; }

		protected IApiAccountRequestModelValidator AccountModelValidator { get; private set; }

		protected IBOLAccountMapper BolAccountMapper { get; private set; }

		protected IDALAccountMapper DalAccountMapper { get; private set; }

		private ILogger logger;

		public AbstractAccountService(
			ILogger logger,
			IAccountRepository accountRepository,
			IApiAccountRequestModelValidator accountModelValidator,
			IBOLAccountMapper bolAccountMapper,
			IDALAccountMapper dalAccountMapper)
			: base()
		{
			this.AccountRepository = accountRepository;
			this.AccountModelValidator = accountModelValidator;
			this.BolAccountMapper = bolAccountMapper;
			this.DalAccountMapper = dalAccountMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAccountResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.AccountRepository.All(limit, offset);

			return this.BolAccountMapper.MapBOToModel(this.DalAccountMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAccountResponseModel> Get(string id)
		{
			var record = await this.AccountRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAccountMapper.MapBOToModel(this.DalAccountMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAccountResponseModel>> Create(
			ApiAccountRequestModel model)
		{
			CreateResponse<ApiAccountResponseModel> response = new CreateResponse<ApiAccountResponseModel>(await this.AccountModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolAccountMapper.MapModelToBO(default(string), model);
				var record = await this.AccountRepository.Create(this.DalAccountMapper.MapBOToEF(bo));

				response.SetRecord(this.BolAccountMapper.MapBOToModel(this.DalAccountMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAccountResponseModel>> Update(
			string id,
			ApiAccountRequestModel model)
		{
			var validationResult = await this.AccountModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolAccountMapper.MapModelToBO(id, model);
				await this.AccountRepository.Update(this.DalAccountMapper.MapBOToEF(bo));

				var record = await this.AccountRepository.Get(id);

				return new UpdateResponse<ApiAccountResponseModel>(this.BolAccountMapper.MapBOToModel(this.DalAccountMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiAccountResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.AccountModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.AccountRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiAccountResponseModel> ByName(string name)
		{
			Account record = await this.AccountRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAccountMapper.MapBOToModel(this.DalAccountMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>63d1ce5d2e57cda30a1147857c739a4e</Hash>
</Codenesium>*/