namespace Salesfly
{
    public class Constants
    {
        ///
        /// Client version.
        ///
        public static string VERSION = "1.0.2";

        ///
        /// Live API URL
        ///
        public const string API_BASE_URL = "https://api.salesfly.com";

        ///
        /// Default timeout is 30 seconds.
        ///
        public const int DEFAULT_TIMEOUT = 30; // in seconds

        ///
        /// Maxiumum number of recipients per mail message
        ///
        public const int MAX_RECIPIENTS = 50;
    }
}
