using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPasswordService: AbstractService
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
			IBOLPasswordMapper bolpasswordMapper,
			IDALPasswordMapper dalpasswordMapper)
			: base()

		{
			this.passwordRepository = passwordRepository;
			this.passwordModelValidator = passwordModelValidator;
			this.bolPasswordMapper = bolpasswordMapper;
			this.dalPasswordMapper = dalpasswordMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPasswordResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.passwordRepository.All(skip, take, orderClause);

			return this.bolPasswordMapper.MapBOToModel(this.dalPasswordMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPasswordResponseModel> Get(int businessEntityID)
		{
			var record = await passwordRepository.Get(businessEntityID);

			return this.bolPasswordMapper.MapBOToModel(this.dalPasswordMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPasswordResponseModel>> Create(
			ApiPasswordRequestModel model)
		{
			CreateResponse<ApiPasswordResponseModel> response = new CreateResponse<ApiPasswordResponseModel>(await this.passwordModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolPasswordMapper.MapModelToBO(default (int), model);
				var record = await this.passwordRepository.Create(this.dalPasswordMapper.MapBOToEF(bo));

				response.SetRecord(this.bolPasswordMapper.MapBOToModel(this.dalPasswordMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiPasswordRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.passwordModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var bo = this.bolPasswordMapper.MapModelToBO(businessEntityID, model);
				await this.passwordRepository.Update(this.dalPasswordMapper.MapBOToEF(bo));
			}

			return response;
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
    <Hash>8a9d4beeab3a464a2f731f1be17d6901</Hash>
</Codenesium>*/