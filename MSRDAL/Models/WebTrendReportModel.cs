using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRDAL.Models
{
    public class WebTrend
    {
        public virtual List<WebTrendSiteDataModel> WebTrendSiteData { get; set; }
        public virtual List<WebTrendNAEPLinkDataModel> WebTrendNAEPLinkData { get; set; }
        public virtual List<WebTrendNRCLinkDataModel> WebTrendNRCLinkData { get; set; }
        public virtual List<WebTrendTermDataModel> WebTrendTermData { get; set; }
        public virtual List<WebTrendResourceDataModel> WebTrendResourceData { get; set; }
    }
    public class WebTrendSiteDataModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Icon { get; set; }
    }
    public class WebTrendNAEPLinkDataModel
    {
        public string Link { get; set; }
        public string Status { get; set; }
        public string Icon { get; set; }
    }
    public class WebTrendNRCLinkDataModel
    {
        public string Link { get; set; }
        public string Status { get; set; }
        public string Icon { get; set; }
    }
    public class WebTrendTermDataModel
    {
        public string Term { get; set; }
        public string Status { get; set; }
        public string Icon { get; set; }
    }
    public class WebTrendResourceDataModel
    {
        public string Description { get; set; }
        public string Status { get; set; }
        public string Icon { get; set; }
    }
}
