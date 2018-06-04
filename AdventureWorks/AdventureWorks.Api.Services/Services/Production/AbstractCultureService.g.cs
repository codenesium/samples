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
	public abstract class AbstractCultureService: AbstractService
	{
		private ICultureRepository cultureRepository;
		private IApiCultureRequestModelValidator cultureModelValidator;
		private IBOLCultureMapper BOLCultureMapper;
		private IDALCultureMapper DALCultureMapper;
		private ILogger logger;

		public AbstractCultureService(
			ILogger logger,
			ICultureRepository cultureRepository,
			IApiCultureRequestModelValidator cultureModelValidator,
			IBOLCultureMapper bolcultureMapper,
			IDALCultureMapper dalcultureMapper)
			: base()

		{
			this.cultureRepository = cultureRepository;
			this.cultureModelValidator = cultureModelValidator;
			this.BOLCultureMapper = bolcultureMapper;
			this.DALCultureMapper = dalcultureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCultureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.cultureRepository.All(skip, take, orderClause);

			return this.BOLCultureMapper.MapBOToModel(this.DALCultureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCultureResponseModel> Get(string cultureID)
		{
			var record = await cultureRepository.Get(cultureID);

			return this.BOLCultureMapper.MapBOToModel(this.DALCultureMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiCultureResponseModel>> Create(
			ApiCultureRequestModel model)
		{
			CreateResponse<ApiCultureResponseModel> response = new CreateResponse<ApiCultureResponseModel>(await this.cultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLCultureMapper.MapModelToBO(default (string), model);
				var record = await this.cultureRepository.Create(this.DALCultureMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLCultureMapper.MapBOToModel(this.DALCultureMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string cultureID,
			ApiCultureRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.cultureModelValidator.ValidateUpdateAsync(cultureID, model));

			if (response.Success)
			{
				var bo = this.BOLCultureMapper.MapModelToBO(cultureID, model);
				await this.cultureRepository.Update(this.DALCultureMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string cultureID)
		{
			ActionResponse response = new ActionResponse(await this.cultureModelValidator.ValidateDeleteAsync(cultureID));

			if (response.Success)
			{
				await this.cultureRepository.Delete(cultureID);
			}
			return response;
		}

		public async Task<ApiCultureResponseModel> GetName(string name)
		{
			Culture record = await this.cultureRepository.GetName(name);

			return this.BOLCultureMapper.MapBOToModel(this.DALCultureMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>040555b9503d3ca19adce35304d9db45</Hash>
</Codenesium>*/