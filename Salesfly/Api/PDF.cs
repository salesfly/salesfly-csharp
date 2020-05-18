using System;
using System.Collections.Generic;
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

            if (!string.IsNullOrEmpty(this.DocumentName))
            {
                jsonObject.Add(new JProperty("document_name", this.DocumentName));
            }
            if (!string.IsNullOrEmpty(this.MarginTop))
            {
                jsonObject.Add(new JProperty("margin_top", this.MarginTop));
            }
            if (!string.IsNullOrEmpty(this.MarginBottom))
            {
                jsonObject.Add(new JProperty("margin_bottom", this.MarginBottom));
            }
            if (!string.IsNullOrEmpty(this.MarginLeft))
            {
                jsonObject.Add(new JProperty("margin_left", this.MarginLeft));
            }
            if (!string.IsNullOrEmpty(this.MarginRight))
            {
                jsonObject.Add(new JProperty("margin_right", this.MarginRight));
            }
            if (!string.IsNullOrEmpty(this.Orientation))
            {
                jsonObject.Add(new JProperty("orientation", this.Orientation));
            }
            if (!string.IsNullOrEmpty(this.PageFormat))
            {
                jsonObject.Add(new JProperty("page_format", this.PageFormat));
            }
            if (!string.IsNullOrEmpty(this.PageWidth))
            {
                jsonObject.Add(new JProperty("page_width", this.PageWidth));
            }
            if (!string.IsNullOrEmpty(this.PageHeight))
            {
                jsonObject.Add(new JProperty("page_height", this.PageHeight));
            }
            if (!string.IsNullOrEmpty(this.PageRanges))
            {
                jsonObject.Add(new JProperty("page_ranges", this.PageRanges));
            }

            if (this.Scale >= 0.1 && this.Scale <= 2.0)
            {
                jsonObject.Add(new JProperty("scale", this.Scale));
            }

            if (!string.IsNullOrEmpty(this.HeaderText))
            {
                jsonObject.Add(new JProperty("header_text", this.HeaderText));
            }
            if (!string.IsNullOrEmpty(this.HeaderAlign))
            {
                jsonObject.Add(new JProperty("header_align", this.HeaderAlign));
            }
            if (this.HeaderMargin > 0)
            {
                jsonObject.Add(new JProperty("header_margin", this.HeaderMargin));
            }
            if (!string.IsNullOrEmpty(this.HeaderHTML))
            {
                jsonObject.Add(new JProperty("header_html", this.HeaderHTML));
            }
            if (!string.IsNullOrEmpty(this.HeaderURL))
            {
                jsonObject.Add(new JProperty("header_url", this.HeaderURL));
            }
            if (!string.IsNullOrEmpty(this.FooterText))
            {
                jsonObject.Add(new JProperty("footer_text", this.FooterText));
            }
            if (!string.IsNullOrEmpty(this.FooterAlign))
            {
                jsonObject.Add(new JProperty("footer_align", this.FooterAlign));
            }
            if (this.FooterMargin > 0)
            {
                jsonObject.Add(new JProperty("footer_margin", this.FooterMargin));
            }
            if (!string.IsNullOrEmpty(this.FooterHTML))
            {
                jsonObject.Add(new JProperty("footer_html", this.FooterHTML));
            }
            if (!string.IsNullOrEmpty(this.FooterURL))
            {
                jsonObject.Add(new JProperty("footer_url", this.FooterURL));
            }
            if (this.PrintBackground)
            {
                jsonObject.Add(new JProperty("print_background", this.PrintBackground));
            }
            if (this.PreferCSSPageSize)
            {
                jsonObject.Add(new JProperty("prefer_css_page_size", this.PreferCSSPageSize));
            }
            if (!string.IsNullOrEmpty(this.WatermarkURL))
            {
                jsonObject.Add(new JProperty("watermark_url", this.WatermarkURL));
            }
            if (!string.IsNullOrEmpty(this.WatermarkPosition))
            {
                jsonObject.Add(new JProperty("watermark_position", this.WatermarkPosition));
            }
            if (this.WatermarkOffsetX > 0)
            {
                jsonObject.Add(new JProperty("watermark_offset_x", this.WatermarkOffsetX));
            }
            if (this.WatermarkOffsetY > 0)
            {
                jsonObject.Add(new JProperty("watermark_offset_y", this.WatermarkOffsetY));
            }
            if (!string.IsNullOrEmpty(this.Title))
            {
                jsonObject.Add(new JProperty("title", this.Title));
            }
            if (!string.IsNullOrEmpty(this.Author))
            {
                jsonObject.Add(new JProperty("author", this.Author));
            }
            if (!string.IsNullOrEmpty(this.Creator))
            {
                jsonObject.Add(new JProperty("creator", this.Creator));
            }
            if (!string.IsNullOrEmpty(this.Subject))
            {
                jsonObject.Add(new JProperty("subject", this.Subject));
            }
            if (this.Keywords != null)
            {
                jsonObject.Add(new JProperty("keywords", this.Keywords));
            }
            if (!string.IsNullOrEmpty(this.Language))
            {
                jsonObject.Add(new JProperty("language", this.Language));
            }
            if (!string.IsNullOrEmpty(this.Encryption))
            {
                jsonObject.Add(new JProperty("encryption", this.Encryption));
            }
            if (!string.IsNullOrEmpty(this.OwnerPassword))
            {
                jsonObject.Add(new JProperty("owner_password", this.OwnerPassword));
            }
            if (!string.IsNullOrEmpty(this.UserPassword))
            {
                jsonObject.Add(new JProperty("user_password", this.UserPassword));
            }
            if (!string.IsNullOrEmpty(this.Permissions))
            {
                jsonObject.Add(new JProperty("permissions", this.Permissions));
            }

            Console.WriteLine(jsonObject.ToString());

            return new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
        }
    }
}