using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestsNS.Api.DataAccess
{
        public class IntegrationTestMigration
        {
                private ApplicationDbContext context;

                public IntegrationTestMigration(ApplicationDbContext context)
                {
                        this.context = context;
                }

                public void Migrate()
                {
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
                        testAllFieldTypeItem1.SetProperties(1, BitConverter.GetBytes(1), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1m, 1m, BitConverter.GetBytes(1), 1m, "A", "A", 1m, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", TimeSpan.Parse("0"), BitConverter.GetBytes(1), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), "A", "A", 1);
                        this.context.TestAllFieldTypes.Add(testAllFieldTypeItem1);

                        var testAllFieldTypesNullableItem1 = new TestAllFieldTypesNullable();
                        testAllFieldTypesNullableItem1.SetProperties(1, BitConverter.GetBytes(1), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1m, 1m, BitConverter.GetBytes(1), 1m, "A", "A", 1m, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", TimeSpan.Parse("0"), BitConverter.GetBytes(1), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), "A", "A", 1);
                        this.context.TestAllFieldTypesNullables.Add(testAllFieldTypesNullableItem1);

                        var timestampCheckItem1 = new TimestampCheck();
                        timestampCheckItem1.SetProperties(1, "A", BitConverter.GetBytes(1));
                        this.context.TimestampChecks.Add(timestampCheckItem1);

                        this.context.SaveChanges();
                        var schemaAPersonItem1 = new SchemaAPerson();
                        schemaAPersonItem1.SetProperties(1, "A");
                        this.context.SchemaAPersons.Add(schemaAPersonItem1);

                        this.context.SaveChanges();
                        var schemaBPersonItem1 = new SchemaBPerson();
                        schemaBPersonItem1.SetProperties(1, "A");
                        this.context.SchemaBPersons.Add(schemaBPersonItem1);

                        var personRefItem1 = new PersonRef();
                        personRefItem1.SetProperties(1, 1, 1);
                        this.context.PersonRefs.Add(personRefItem1);

                        this.context.SaveChanges();
                }
        }
}

/*<Codenesium>
    <Hash>8bbfbc10e9e3984d32638016589ede41</Hash>
</Codenesium>*/