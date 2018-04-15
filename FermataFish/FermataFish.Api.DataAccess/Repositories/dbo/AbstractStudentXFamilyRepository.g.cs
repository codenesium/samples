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
	public abstract class AbstractStudentXFamilyRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractStudentXFamilyRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			StudentXFamilyModel model)
		{
			var record = new EFStudentXFamily();

			this.mapper.StudentXFamilyMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFStudentXFamily>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			StudentXFamilyModel model)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{id}");
			}
			else
			{
				this.mapper.StudentXFamilyMapModelToEF(
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
				this.context.Set<EFStudentXFamily>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int id)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCOStudentXFamily GetByIdDirect(int id)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.StudentXFamilies.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOStudentXFamily> GetWhereDirect(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.StudentXFamilies;
		}

		private void SearchLinqPOCO(Expression<Func<EFStudentXFamily, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFStudentXFamily> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.StudentXFamilyMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFStudentXFamily> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.StudentXFamilyMapEFToPOCO(x, response));
		}

		protected virtual List<EFStudentXFamily> SearchLinqEF(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFStudentXFamily> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>d409ec9a598d259868da73e5f4eb22fa</Hash>
</Codenesium>*/