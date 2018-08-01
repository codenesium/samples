using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractClaspService : AbstractService
	{
		private IClaspRepository claspRepository;

		private IApiClaspRequestModelValidator claspModelValidator;

		private IBOLClaspMapper bolClaspMapper;

		private IDALClaspMapper dalClaspMapper;

		private ILogger logger;

		public AbstractClaspService(
			ILogger logger,
			IClaspRepository claspRepository,
			IApiClaspRequestModelValidator claspModelValidator,
			IBOLClaspMapper bolClaspMapper,
			IDALClaspMapper dalClaspMapper)
			: base()
		{
			this.claspRepository = claspRepository;
			this.claspModelValidator = claspModelValidator;
			this.bolClaspMapper = bolClaspMapper;
			this.dalClaspMapper = dalClaspMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiClaspResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.claspRepository.All(limit, offset);

			return this.bolClaspMapper.MapBOToModel(this.dalClaspMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiClaspResponseModel> Get(int id)
		{
			var record = await this.claspRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolClaspMapper.MapBOToModel(this.dalClaspMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiClaspResponseModel>> Create(
			ApiClaspRequestModel model)
		{
			CreateResponse<ApiClaspResponseModel> response = new CreateResponse<ApiClaspResponseModel>(await this.claspModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolClaspMapper.MapModelToBO(default(int), model);
				var record = await this.claspRepository.Create(this.dalClaspMapper.MapBOToEF(bo));

				response.SetRecord(this.bolClaspMapper.MapBOToModel(this.dalClaspMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiClaspResponseModel>> Update(
			int id,
			ApiClaspRequestModel model)
		{
			var validationResult = await this.claspModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolClaspMapper.MapModelToBO(id, model);
				await this.claspRepository.Update(this.dalClaspMapper.MapBOToEF(bo));

				var record = await this.claspRepository.Get(id);

				return new UpdateResponse<ApiClaspResponseModel>(this.bolClaspMapper.MapBOToModel(this.dalClaspMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiClaspResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.claspRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bc8499d311220e26fbc24be056353461</Hash>
</Codenesium>*/