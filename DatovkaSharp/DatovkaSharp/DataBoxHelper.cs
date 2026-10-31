using System.Collections.Generic;

namespace DatovkaSharp
{
    /// <summary>
    /// Helper class for Czech Data Box constants and utilities
    /// </summary>
    public static class DataBoxHelper
    {
        // Service type constants
        public const int OPERATIONS_WS = 0;
        public const int INFO_WS = 1;
        public const int SEARCH_WS = 2;
        public const int ACCESS_WS = 3;
        public const int STAT_WS = 4;
        public const int VODZ_WS = 5;

        /// <summary>
        /// Data Box types
        /// </summary>
        public static Dictionary<string, string> DataBoxTypes => new Dictionary<string, string>
        {
            { "FO", "Fyzická osoba" },
            { "PFO", "Podnikající fyzická osoba" },
            { "PFO_ADVOK", "Advokát" },
            { "PFO_DANPOR", "Daňový poradce" },
            { "PFO_INSSPR", "Insolvenční správce" },
            { "PO", "Právnická osoba" },
            { "PO_ZAK", "PO_ZAK" },
            { "PO_REQ", "PO_REQ" },
            { "OVM", "Orgán veřejné moci" },
            { "OVM_NOTAR", "Notář" },
            { "OVM_EXEKUT", "Exekutor" },
            { "OVM_REQ", "OVM_REQ" }
        };

        /// <summary>
        /// Message states
        /// </summary>
        public static Dictionary<int, string> MessageStates => new Dictionary<int, string>
        {
            { 1, "Podáno" },
            { 2, "Odeslána" },
            { 3, "Chyba - vir" },
            { 4, "Dodána" },
            { 5, "Doručeno fikcí" },
            { 6, "Doručeno" },
            { 7, "Přečteno" },
            { 8, "Nedoručitelné" },
            { 9, "Smazáno" },
            { 10, "Datový trezor" }
        };

        /// <summary>
        /// Message state descriptions
        /// </summary>
        public static Dictionary<int, string> MessageStateDescriptions => new Dictionary<int, string>
        {
            { 1, "Zpráva byla podána (vznikla v ISDS)" },
            { 2, "Datová zpráva včetně písemností podepsána časovým razítkem" },
            { 3, "Zpráva neprošla AV kontrolou; nakažená písemnost je smazána; konečný stav zprávy před smazáním" },
            { 4, "Zpráva dodána do ISDS (zapsán čas dodání)" },
            { 5, "Uplynulo 10 dní od dodání veřejné zprávy, která dosud nebyla doručena přihlášením (předpoklad doručení fikcí u neOVM DS); u komerční zprávy nemůže tento stav nastat" },
            { 6, "Osoba oprávněná číst tuto zprávu se přihlásila - dodaná zpráva byla doručena" },
            { 7, "Zpráva byla přečtena (na portále nebo akcí ESS)" },
            { 8, "Zpráva byla označena jako nedoručitelná, protože DS adresáta byla zpětně znepřístupněna" },
            { 9, "Obsah zprávy byl smazán, obálka zprávy včetně hashů přesunuta do archivu" },
            { 10, "Zpráva je v Datovém trezoru" }
        };

        /// <summary>
        /// MIME type ISDS expects for each permitted attachment extension: the operator's list
        /// "Seznam povolených přípon příloh zprávy" (WS_manipulace_s_datovymi_zpravami, Provozní řád
        /// of 26 June 2026), taking its preferred type where it lists several. ISDS tests the declared
        /// type against the content, and a ZIP or ASiC container must declare its own.
        /// </summary>
        private static readonly Dictionary<string, string> MimeTypes = new Dictionary<string, string>
        {
            { "asice", "application/vnd.etsi.asic-e+zip" },
            { "asics", "application/vnd.etsi.asic-s+zip" },
            { "cer", "application/x-x509-ca-cert" },
            { "crt", "application/x-x509-ca-cert" },
            { "csv", "text/csv" },
            { "dbf", "application/octet-stream" },
            { "ddd", "application/octet-stream" },
            { "der", "application/x-x509-ca-cert" },
            { "dgn", "application/octet-stream" },
            { "doc", "application/msword" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "dwg", "image/vnd.dwg" },
            { "edi", "application/edifact" },
            { "fo", "application/vnd.software602.filler.form+xml" },
            { "gfs", "application/xml" },
            { "gif", "image/gif" },
            { "gml", "application/xml" },
            { "heic", "image/heic" },
            { "heif", "image/heif" },
            { "htm", "text/html" },
            { "html", "text/html" },
            { "isdoc", "text/isdoc" },
            { "isdocx", "text/isdocx" },
            { "jfif", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "jpg", "image/jpeg" },
            { "json", "application/json" },
            { "m4a", "audio/mp4" },
            { "m4p", "audio/mp4" },
            { "m4v", "video/mp4" },
            { "mp2", "audio/mpeg" },
            { "mp3", "audio/mpeg" },
            { "mp4", "audio/mp4" },
            { "mpeg", "video/mpeg" },
            { "mpeg1", "video/mpeg" },
            { "mpeg2", "video/mpeg" },
            { "mpg", "video/mpeg" },
            { "odp", "application/vnd.oasis.opendocument.presentation" },
            { "ods", "application/vnd.oasis.opendocument.spreadsheet" },
            { "odt", "application/vnd.oasis.opendocument.text" },
            { "p7b", "application/pkcs7-certificates" },
            { "p7c", "application/pkcs7-mime" },
            { "p7f", "application/pkcs7-signature" },
            { "p7m", "application/pkcs7-mime" },
            { "p7s", "application/pkcs7-signature" },
            { "pdf", "application/pdf" },
            { "pk7", "application/pkcs7-mime" },
            { "png", "image/png" },
            { "ppt", "application/vnd.ms-powerpoint" },
            { "pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" },
            { "prj", "application/octet-stream" },
            { "qix", "application/octet-stream" },
            { "rtf", "application/msword" },
            { "sbn", "application/octet-stream" },
            { "sbx", "application/octet-stream" },
            { "sce", "application/vnd.etsi.asic-e+zip" },
            { "scs", "application/vnd.etsi.asic-s+zip" },
            { "shp", "application/octet-stream" },
            { "shx", "application/octet-stream" },
            { "tif", "image/tiff" },
            { "tiff", "image/tiff" },
            { "tsr", "application/timestamp-reply" },
            { "tst", "application/timestamp-reply" },
            { "txt", "text/plain" },
            { "wav", "audio/wav" },
            { "xls", "application/vnd.ms-excel" },
            { "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
            { "xml", "application/xml" },
            { "xsd", "application/xml" },
            { "zfo", "application/vnd.software602.filler.form-xml-zip" },
            { "zip", "application/zip" },
        };

        /// <summary>
        /// Get MIME type for a file. An extension outside the operator's list, which ISDS refuses
        /// anyway, gets application/octet-stream.
        /// </summary>
        public static string GetMimeType(string fileName)
        {
            string extension = System.IO.Path.GetExtension(fileName)?.TrimStart('.').ToLowerInvariant() ?? string.Empty;
            return MimeTypes.TryGetValue(extension, out string? type) ? type : "application/octet-stream";
        }
    }
}
