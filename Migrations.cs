using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Moov2.Orchard.SocialShare
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("SocialSharePartRecord",
                table => table
                    .ContentPartVersionRecord()
                    .Column<bool>("DisplayTwitter")
                    .Column<string>("TwitterText", column => column.WithLength(150))
                );

            ContentDefinitionManager.AlterPartDefinition("SocialSharePart", builder => builder
                .WithDescription("Adds social sharing options to content types.")
                .Attachable());

            return 1;
        }
    }
}