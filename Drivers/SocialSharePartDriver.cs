using Moov2.Orchard.SocialShare.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;
namespace Moov2.Orchard.SocialShare.Drivers
{
    public class SocialSharePartDriver : ContentPartDriver<SocialSharePart>
    {
        #region Constants

        private const string TemplateName = "Parts.SocialShare.SocialSharePart";

        #endregion

        #region Dependencies

        public Localizer T { get; set; }

        #endregion

        #region Overrides

        protected override string Prefix
        {
            get { return "SocialShare"; }
        }

        #endregion

        #region Display

        protected override DriverResult Display(SocialSharePart part, string displayType, dynamic shapeHelper)
        {
            if(displayType == "Detail")
            {
                return ContentShape("Parts_SocialShare",
                    () => shapeHelper.Parts_SocialShare(
                        Part: part,
                        DisplayTwitter: part.DisplayTwitter,
                        TwitterText: part.TwitterText,
                        DisplayFacebook: part.DisplayFacebook
                ));
            }

            return Combined(
                ContentShape("Parts_SocialShare_SummaryAdmin",
                    () => shapeHelper.Parts_SocialShare_SummaryAdmin(Part: part))
                );

        }
        
        #endregion

        #region Editor

        protected override DriverResult Editor(SocialSharePart part, dynamic shapeHelper)
        {

            return ContentShape("Parts_SocialShare_Edit",
                () => shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(SocialSharePart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);

            return Editor(part, shapeHelper);
        }

        #endregion

        #region Import/Export

        protected override void Importing(SocialSharePart part, ImportContentContext context)
        {
            // Don't do anything if the tag is not specified.
            if (context.Data.Element(part.PartDefinition.Name) == null)
                return;

            context.ImportAttribute(part.PartDefinition.Name, "DisplayTwitter", displayTwitter => part.DisplayTwitter = bool.Parse(displayTwitter));
            context.ImportAttribute(part.PartDefinition.Name, "TwitterText", twitterText => part.TwitterText = twitterText);
        }

        protected override void Exporting(SocialSharePart part, ExportContentContext context)
        {
            context.Element(part.PartDefinition.Name).SetAttributeValue("DisplayTwitter", part.DisplayTwitter);
            context.Element(part.PartDefinition.Name).SetAttributeValue("TwitterText", part.TwitterText);
        }

        #endregion
    }
}