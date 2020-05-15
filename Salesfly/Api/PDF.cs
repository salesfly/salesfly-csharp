using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

using Salesfly.Exceptions;

namespace Salesfly.Api
{
    /// <summary>
    /// The PDF API is an easy way to create PDF documents from HTML.
    /// </summary>
    public class PDF : ApiBase
    {
        private PDF() { }

        /// <summary>
        /// Creates a PDF document for the given options.
        /// </summary>
        public static async Task<byte[]> CreateAsync(PDFOptions options)
        {
            //check for parameters
            ThrowIf.IsArgumentNull(() => options);

            var client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, SalesflyClient.GetTimeout());
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "salesfly-csharp/" + Constants.VERSION);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + SalesflyClient.GetApiKey());
            client.DefaultRequestHeaders.Add("Accept", "application/pdf");

            var payload = options.ToContent();

            var response = await client.PostAsync(Constants.API_BASE_URL + "/v1/pdf/create", payload);
            return await GetRawBody(response);
        }
    }

    /// <summary>
    /// Options for creating PDF documents.
    /// </summary>
    public class PDFOptions
    {
        ///
        /// Constructor
        ///
        public PDFOptions() { }

        ///
        /// A URL pointing to a web page. 
        ///
        [JsonProperty("document_url")]
        public string DocumentURL { get; set; }

        ///
        /// A string containing HTML.
        ///
        [JsonProperty("document_html")]
        public string DocumentHTML { get; set; }

        ///
        /// Name of the returned document. Defaults to 'document.
        ///
        [JsonProperty("document_name")]
        public string DocumentName { get; set; }

        ///
        /// Top margin, accepts values labeled with units. Example: '20mm'.
        ///
        [JsonProperty("margin_top")]
        public string MarginTop { get; set; }

        ///
        /// Bottom margin, accepts values labeled with units.                              
        ///
        [JsonProperty("margin_bottom")]
        public string MarginBottom { get; set; }

        ///
        /// Left margin, accepts values labeled with units.                             
        ///
        [JsonProperty("margin_left")]
        public string MarginLeft { get; set; }

        ///
        /// Right margin, accepts values labeled with units.           
        ///
        [JsonProperty("margin_right")]
        public string MarginRight { get; set; }

        ///
        /// Paper orientation: 'landscape' or 'portrait'. Defaults to 'portrait'. 
        ///
        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        ///
        /// Paper format. Defaults to 'A4'.
        ///
        [JsonProperty("page_format")]
        public string PageFormat { get; set; }

        ///
        /// Paper width, accepts values labeled with units. If set together with PageHeight, takes priority over PageFormat. 
        ///
        [JsonProperty("page_width")]
        public string PageWidth { get; set; }

        ///
        /// Paper height, accepts values labeled with units. If set together with PageWidth, takes priority over PageFormat.
        ///
        [JsonProperty("page_height")]
        public string PageHeight { get; set; }

        ///
        /// Paper ranges to print, e.g., '1-5, 8, 11-13'. Defaults to the empty string, which means print all pages.
        ///
        [JsonProperty("page_ranges")]
        public string PageRanges { get; set; }

        ///
        /// Scale of the webpage rendering. Defaults to 1. Scale amount must be between 0.1 and 2.                        
        ///
        [JsonProperty("scale")]
        public double Scale { get; set; }

        ///
        /// Header text to be displayed at the top of each page.   
        ///
        [JsonProperty("header_text")]
        public string HeaderText { get; set; }

        ///
        /// Header alignment: 'left', 'center' or 'right'. Defaults to 'center. 
        ///
        [JsonProperty("header_align")]
        public string HeaderAlign { get; set; }

        ///
        /// Left and right margin for header (only applied when using HeaderText).
        ///
        [JsonProperty("header_margin")]
        public int HeaderMargin { get; set; }

        ///
        /// HTML template for the header. 
        ///
        [JsonProperty("header_html")]
        public string HeaderHTML { get; set; }

        ///
        /// A URL pointing to a HTML template for the header.   
        ///
        [JsonProperty("header_url")]
        public string HeaderURL { get; set; }

        ///
        /// Footer text to be displayed at the bottom of each page. 
        ///
        [JsonProperty("footer_text")]
        public string FooterText { get; set; }

        ///
        /// Footer alignment: 'left', 'center' or 'right'. Defaults to 'center. 
        ///
        [JsonProperty("footer_align")]
        public string FooterAlign { get; set; }

        ///
        /// Left and right margin for footer (only applied using FooterText). 
        ///
        [JsonProperty("footer_margin")]
        public int FooterMargin { get; set; }

        ///
        /// HTML template for the footer. 
        ///
        [JsonProperty("footer_html")]
        public string FooterHTML { get; set; }

        ///
        /// A URL pointing to a HTML template for the footer. 
        ///
        [JsonProperty("footer_url")]
        public string FooterURL { get; set; }

        ///
        /// Print background graphics. Defaults to false.  
        ///
        [JsonProperty("print_background")]
        public bool PrintBackground { get; set; }

        ///
        /// Give any CSS @page size declared in the page priority over what is declared in `width` and `height` or `format` options. Defaults to false, which will scale the content to fit the paper size. 
        ///
        [JsonProperty("prefer_css_page_size")]
        public bool PreferCSSPageSize { get; set; }

        ///
        /// A URL pointing to a PNG or JPEG image that will be used as a watermark.
        ///
        [JsonProperty("watermark_url")]
        public string WatermarkURL { get; set; }

        ///
        /// A string telling where to place the watermark on the page: 'topleft', 'topright', 'center', 'bottomleft', 'bottomright'. Defaults to 'center'. 
        ///
        [JsonProperty("watermark_position")]
        public string WatermarkPosition { get; set; }

        ///
        /// The number of pixels to shift the watermark image horizontally. Offset is given in pixels. Defaults to 0.
        ///
        [JsonProperty("watermark_offset_x")]
        public int WatermarkOffsetX { get; set; }

        ///
        /// The number of pixels to shift the watermark image vertically. Offset is given in pixels. Defaults to 0.    
        ///
        [JsonProperty("watermark_offset_y")]
        public int WatermarkOffsetY { get; set; }

        ///
        /// The title of this document.  
        ///
        [JsonProperty("title")]
        public string Title { get; set; }

        ///
        /// The author of this document.  
        ///
        [JsonProperty("author")]
        public string Author { get; set; }

        ///
        /// The creator of this document. 
        ///
        [JsonProperty("creator")]
        public string Creator { get; set; }

        ///
        /// The subject of this document. 
        ///
        [JsonProperty("subject")]
        public string Subject { get; set; }

        ///
        /// An array of keywords associated with this document. 
        ///
        [JsonProperty("keywords")]
        public string[] Keywords { get; set; }

        ///
        /// A RFC 3066 language-tag denoting the language of this document, or an empty string if the language is unknown.
        ///
        [JsonProperty("language")]
        public string Language { get; set; }

        ///
        /// Encrypt the PDF document using one of following algorithms: 'aes-256', 'aes-128', 'rc4-128' or 'rc4-40'.
        ///
        [JsonProperty("encryption")]
        public string Encryption { get; set; }

        ///
        /// Set the owner password (required when encryption is enabled).
        ///
        [JsonProperty("owner_password")]
        public string OwnerPassword { get; set; }

        ///
        /// Set the user password. 
        ///
        [JsonProperty("user_password")]
        public string UserPassword { get; set; }

        ///
        /// Set user permissions 'all' or 'none'. Defaults to 'all'.  
        ///
        [JsonProperty("permissions")]
        public string Permissions { get; set; }

        public HttpContent ToContent()
        {
            var jsonObject = new JObject();

            if (!string.IsNullOrEmpty(this.DocumentURL))
            {
                jsonObject.Add(new JProperty("document_url", this.DocumentURL));
            }
            else if (!string.IsNullOrEmpty(this.DocumentHTML))
            {
                jsonObject.Add(new JProperty("document_html", this.DocumentHTML));
            }

            //FIXME: add all params

            return new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
        }
    }
}