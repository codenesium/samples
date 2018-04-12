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

		public AbstractStudentXFamilyRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			int studentId,
			int familyId)
		{
			var record = new EFStudentXFamily();

			MapPOCOToEF(
				0,
				studentId,
				familyId,
				record);

			this.context.Set<EFStudentXFamily>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			int studentId,
			int familyId)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{id}");
			}
			else
			{
				MapPOCOToEF(
					id,
					studentId,
					familyId,
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

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCOStudentXFamily GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.StudentXFamilies.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOStudentXFamily> GetWhereDirect(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.StudentXFamilies;
		}

		private void SearchLinqPOCO(Expression<Func<EFStudentXFamily, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFStudentXFamily> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFStudentXFamily> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFStudentXFamily> SearchLinqEF(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFStudentXFamily> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int id,
			int studentId,
			int familyId,
			EFStudentXFamily efStudentXFamily)
		{
			efStudentXFamily.SetProperties(id.ToInt(), studentId.ToInt(), familyId.ToInt());
		}

		public static void MapEFToPOCO(
			EFStudentXFamily efStudentXFamily,
			Response response)
		{
			if (efStudentXFamily == null)
			{
				return;
			}

			response.AddStudentXFamily(new POCOStudentXFamily(efStudentXFamily.Id.ToInt(), efStudentXFamily.StudentId.ToInt(), efStudentXFamily.FamilyId.ToInt()));

			StudentRepository.MapEFToPOCO(efStudentXFamily.Student, response);

			FamilyRepository.MapEFToPOCO(efStudentXFamily.Family, response);
		}
	}
}

/*<Codenesium>
    <Hash>784aa760dce8b70dbba7158181d7aefa</Hash>
</Codenesium>*/