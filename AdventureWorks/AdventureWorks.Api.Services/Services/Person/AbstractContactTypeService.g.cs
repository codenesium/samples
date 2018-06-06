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
	public abstract class AbstractContactTypeService: AbstractService
	{
		private IContactTypeRepository contactTypeRepository;
		private IApiContactTypeRequestModelValidator contactTypeModelValidator;
		private IBOLContactTypeMapper bolContactTypeMapper;
		private IDALContactTypeMapper dalContactTypeMapper;
		private ILogger logger;

		public AbstractContactTypeService(
			ILogger logger,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeRequestModelValidator contactTypeModelValidator,
			IBOLContactTypeMapper bolcontactTypeMapper,
			IDALContactTypeMapper dalcontactTypeMapper)
			: base()

		{
			this.contactTypeRepository = contactTypeRepository;
			this.contactTypeModelValidator = contactTypeModelValidator;
			this.bolContactTypeMapper = bolcontactTypeMapper;
			this.dalContactTypeMapper = dalcontactTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiContactTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.contactTypeRepository.All(skip, take, orderClause);

			return this.bolContactTypeMapper.MapBOToModel(this.dalContactTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiContactTypeResponseModel> Get(int contactTypeID)
		{
			var record = await contactTypeRepository.Get(contactTypeID);

			return this.bolContactTypeMapper.MapBOToModel(this.dalContactTypeMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiContactTypeResponseModel>> Create(
			ApiContactTypeRequestModel model)
		{
			CreateResponse<ApiContactTypeResponseModel> response = new CreateResponse<ApiContactTypeResponseModel>(await this.contactTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolContactTypeMapper.MapModelToBO(default (int), model);
				var record = await this.contactTypeRepository.Create(this.dalContactTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.bolContactTypeMapper.MapBOToModel(this.dalContactTypeMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int contactTypeID,
			ApiContactTypeRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.contactTypeModelValidator.ValidateUpdateAsync(contactTypeID, model));

			if (response.Success)
			{
				var bo = this.bolContactTypeMapper.MapModelToBO(contactTypeID, model);
				await this.contactTypeRepository.Update(this.dalContactTypeMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int contactTypeID)
		{
			ActionResponse response = new ActionResponse(await this.contactTypeModelValidator.ValidateDeleteAsync(contactTypeID));

			if (response.Success)
			{
				await this.contactTypeRepository.Delete(contactTypeID);
			}
			return response;
		}

		public async Task<ApiContactTypeResponseModel> GetName(string name)
		{
			ContactType record = await this.contactTypeRepository.GetName(name);

			return this.bolContactTypeMapper.MapBOToModel(this.dalContactTypeMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>32caefed79ccb184b0d31dfce720be6b</Hash>
</Codenesium>*/