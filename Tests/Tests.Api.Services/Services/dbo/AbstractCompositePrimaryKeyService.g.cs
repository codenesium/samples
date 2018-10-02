using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractCompositePrimaryKeyService : AbstractService
	{
		protected ICompositePrimaryKeyRepository CompositePrimaryKeyRepository { get; private set; }

		protected IApiCompositePrimaryKeyRequestModelValidator CompositePrimaryKeyModelValidator { get; private set; }

		protected IBOLCompositePrimaryKeyMapper BolCompositePrimaryKeyMapper { get; private set; }

		protected IDALCompositePrimaryKeyMapper DalCompositePrimaryKeyMapper { get; private set; }

		private ILogger logger;

		public AbstractCompositePrimaryKeyService(
			ILogger logger,
			ICompositePrimaryKeyRepository compositePrimaryKeyRepository,
			IApiCompositePrimaryKeyRequestModelValidator compositePrimaryKeyModelValidator,
			IBOLCompositePrimaryKeyMapper bolCompositePrimaryKeyMapper,
			IDALCompositePrimaryKeyMapper dalCompositePrimaryKeyMapper)
			: base()
		{
			this.CompositePrimaryKeyRepository = compositePrimaryKeyRepository;
			this.CompositePrimaryKeyModelValidator = compositePrimaryKeyModelValidator;
			this.BolCompositePrimaryKeyMapper = bolCompositePrimaryKeyMapper;
			this.DalCompositePrimaryKeyMapper = dalCompositePrimaryKeyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCompositePrimaryKeyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CompositePrimaryKeyRepository.All(limit, offset);

			return this.BolCompositePrimaryKeyMapper.MapBOToModel(this.DalCompositePrimaryKeyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCompositePrimaryKeyResponseModel> Get(int id)
		{
			var record = await this.CompositePrimaryKeyRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCompositePrimaryKeyMapper.MapBOToModel(this.DalCompositePrimaryKeyMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCompositePrimaryKeyResponseModel>> Create(
			ApiCompositePrimaryKeyRequestModel model)
		{
			CreateResponse<ApiCompositePrimaryKeyResponseModel> response = new CreateResponse<ApiCompositePrimaryKeyResponseModel>(await this.CompositePrimaryKeyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCompositePrimaryKeyMapper.MapModelToBO(default(int), model);
				var record = await this.CompositePrimaryKeyRepository.Create(this.DalCompositePrimaryKeyMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCompositePrimaryKeyMapper.MapBOToModel(this.DalCompositePrimaryKeyMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCompositePrimaryKeyResponseModel>> Update(
			int id,
			ApiCompositePrimaryKeyRequestModel model)
		{
			var validationResult = await this.CompositePrimaryKeyModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCompositePrimaryKeyMapper.MapModelToBO(id, model);
				await this.CompositePrimaryKeyRepository.Update(this.DalCompositePrimaryKeyMapper.MapBOToEF(bo));

				var record = await this.CompositePrimaryKeyRepository.Get(id);

				return new UpdateResponse<ApiCompositePrimaryKeyResponseModel>(this.BolCompositePrimaryKeyMapper.MapBOToModel(this.DalCompositePrimaryKeyMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCompositePrimaryKeyResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.CompositePrimaryKeyModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.CompositePrimaryKeyRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e8ede07f1feae7561522b861d5595d61</Hash>
</Codenesium>*/