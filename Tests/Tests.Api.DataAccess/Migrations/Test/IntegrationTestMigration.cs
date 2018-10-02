using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public class IntegrationTestMigration
	{
		private ApplicationDbContext context;

		public IntegrationTestMigration(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async void Migrate()
		{
			var columnSameAsFKTableItem1 = new ColumnSameAsFKTable();
			columnSameAsFKTableItem1.SetProperties(1, 1, 1);
			this.context.ColumnSameAsFKTables.Add(columnSameAsFKTableItem1);

			var compositePrimaryKeyItem1 = new CompositePrimaryKey();
			compositePrimaryKeyItem1.SetProperties(1, 1);
			this.context.CompositePrimaryKeys.Add(compositePrimaryKeyItem1);

			var includedColumnTestItem1 = new IncludedColumnTest();
			includedColumnTestItem1.SetProperties(1, "A", "A");
			this.context.IncludedColumnTests.Add(includedColumnTestItem1);

			var personItem1 = new Person();
			personItem1.SetProperties(1, "A");
			this.context.People.Add(personItem1);

			var rowVersionCheckItem1 = new RowVersionCheck();
			rowVersionCheckItem1.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			this.context.RowVersionChecks.Add(rowVersionCheckItem1);

			var selfReferenceItem1 = new SelfReference();
			selfReferenceItem1.SetProperties(1, 1, 1);
			this.context.SelfReferences.Add(selfReferenceItem1);

			var tableItem1 = new Table();
			tableItem1.SetProperties(1, "A");
			this.context.Tables.Add(tableItem1);

			var testAllFieldTypeItem1 = new TestAllFieldType();
			testAllFieldTypeItem1.SetProperties(1, BitConverter.GetBytes(1), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, 1, BitConverter.GetBytes(1), 1m, "A", "A", 1m, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", TimeSpan.Parse("0"), BitConverter.GetBytes(1), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), "A", "A", 1);
			this.context.TestAllFieldTypes.Add(testAllFieldTypeItem1);

			var testAllFieldTypesNullableItem1 = new TestAllFieldTypesNullable();
			testAllFieldTypesNullableItem1.SetProperties(1, BitConverter.GetBytes(1), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, 1, BitConverter.GetBytes(1), 1m, "A", "A", 1m, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", TimeSpan.Parse("0"), BitConverter.GetBytes(1), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), "A", "A", 1);
			this.context.TestAllFieldTypesNullables.Add(testAllFieldTypesNullableItem1);

			var timestampCheckItem1 = new TimestampCheck();
			timestampCheckItem1.SetProperties(1, "A", BitConverter.GetBytes(1));
			this.context.TimestampChecks.Add(timestampCheckItem1);

			var vPersonItem1 = new VPerson();
			vPersonItem1.SetProperties(1, "A");
			this.context.VPersons.Add(vPersonItem1);

			await this.context.SaveChangesAsync();

			var schemaAPersonItem1 = new SchemaAPerson();
			schemaAPersonItem1.SetProperties(1, "A");
			this.context.SchemaAPersons.Add(schemaAPersonItem1);

			await this.context.SaveChangesAsync();

			var schemaBPersonItem1 = new SchemaBPerson();
			schemaBPersonItem1.SetProperties(1, "A");
			this.context.SchemaBPersons.Add(schemaBPersonItem1);

			var personRefItem1 = new PersonRef();
			personRefItem1.SetProperties(1, 1, 1);
			this.context.PersonRefs.Add(personRefItem1);

			await this.context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>00badb6032e59b729a169c9cb12925aa</Hash>
</Codenesium>*/