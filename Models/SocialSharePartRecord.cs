using Orchard.ContentManagement.Records;

namespace Moov2.Orchard.SocialShare.Models
{
    public class SocialSharePartRecord : ContentPartVersionRecord
    {
        public bool DisplayTwitter { get; set; }
        public string TwitterText { get; set; }

        public bool DisplayFacebook { get; set; }
    }
}