using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPasswordService : AbstractService
	{
		private IPasswordRepository passwordRepository;

		private IApiPasswordRequestModelValidator passwordModelValidator;

		private IBOLPasswordMapper bolPasswordMapper;

		private IDALPasswordMapper dalPasswordMapper;

		private ILogger logger;

		public AbstractPasswordService(
			ILogger logger,
			IPasswordRepository passwordRepository,
			IApiPasswordRequestModelValidator passwordModelValidator,
			IBOLPasswordMapper bolPasswordMapper,
			IDALPasswordMapper dalPasswordMapper)
			: base()
		{
			this.passwordRepository = passwordRepository;
			this.passwordModelValidator = passwordModelValidator;
			this.bolPasswordMapper = bolPasswordMapper;
			this.dalPasswordMapper = dalPasswordMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPasswordResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.passwordRepository.All(limit, offset);

			return this.bolPasswordMapper.MapBOToModel(this.dalPasswordMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPasswordResponseModel> Get(int businessEntityID)
		{
			var record = await this.passwordRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolPasswordMapper.MapBOToModel(this.dalPasswordMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPasswordResponseModel>> Create(
			ApiPasswordRequestModel model)
		{
			CreateResponse<ApiPasswordResponseModel> response = new CreateResponse<ApiPasswordResponseModel>(await this.passwordModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolPasswordMapper.MapModelToBO(default(int), model);
				var record = await this.passwordRepository.Create(this.dalPasswordMapper.MapBOToEF(bo));

				response.SetRecord(this.bolPasswordMapper.MapBOToModel(this.dalPasswordMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPasswordResponseModel>> Update(
			int businessEntityID,
			ApiPasswordRequestModel model)
		{
			var validationResult = await this.passwordModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolPasswordMapper.MapModelToBO(businessEntityID, model);
				await this.passwordRepository.Update(this.dalPasswordMapper.MapBOToEF(bo));

				var record = await this.passwordRepository.Get(businessEntityID);

				return new UpdateResponse<ApiPasswordResponseModel>(this.bolPasswordMapper.MapBOToModel(this.dalPasswordMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPasswordResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.passwordModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.passwordRepository.Delete(businessEntityID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fe26ca382fe2d786f79288e5e355bb44</Hash>
</Codenesium>*/