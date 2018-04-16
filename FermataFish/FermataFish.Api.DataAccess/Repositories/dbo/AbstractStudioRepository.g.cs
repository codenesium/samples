using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractStudioRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractStudioRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			StudioModel model)
		{
			var record = new EFStudio();

			this.mapper.StudioMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFStudio>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			StudioModel model)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{id}");
			}
			else
			{
				this.mapper.StudioMapModelToEF(
					id,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFStudio>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int id)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCOStudio GetByIdDirect(int id)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.Studios.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFStudio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOStudio> GetWhereDirect(Expression<Func<EFStudio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Studios;
		}

		private void SearchLinqPOCO(Expression<Func<EFStudio, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFStudio> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.StudioMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFStudio> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.StudioMapEFToPOCO(x, response));
		}

		protected virtual List<EFStudio> SearchLinqEF(Expression<Func<EFStudio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFStudio> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>fbe7f3ba8ab2aaffbad3a7a058866014</Hash>
</Codenesium>*/