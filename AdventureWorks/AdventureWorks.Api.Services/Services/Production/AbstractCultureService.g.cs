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
		private IBOLCultureMapper bolCultureMapper;
		private IDALCultureMapper dalCultureMapper;
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
			this.bolCultureMapper = bolcultureMapper;
			this.dalCultureMapper = dalcultureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCultureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.cultureRepository.All(skip, take, orderClause);

			return this.bolCultureMapper.MapBOToModel(this.dalCultureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCultureResponseModel> Get(string cultureID)
		{
			var record = await cultureRepository.Get(cultureID);

			return this.bolCultureMapper.MapBOToModel(this.dalCultureMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiCultureResponseModel>> Create(
			ApiCultureRequestModel model)
		{
			CreateResponse<ApiCultureResponseModel> response = new CreateResponse<ApiCultureResponseModel>(await this.cultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolCultureMapper.MapModelToBO(default (string), model);
				var record = await this.cultureRepository.Create(this.dalCultureMapper.MapBOToEF(bo));

				response.SetRecord(this.bolCultureMapper.MapBOToModel(this.dalCultureMapper.MapEFToBO(record)));
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
				var bo = this.bolCultureMapper.MapModelToBO(cultureID, model);
				await this.cultureRepository.Update(this.dalCultureMapper.MapBOToEF(bo));
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

			return this.bolCultureMapper.MapBOToModel(this.dalCultureMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>59a489a8672e1b8513e377fc61a6f8a7</Hash>
</Codenesium>*/