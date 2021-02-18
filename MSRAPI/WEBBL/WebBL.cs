using MSRDAL.Models;
using MSRDAL.Entities;
using MSRDAL.AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MSRAPI.WEBBL
{
    public class WebBL
    {
        public async Task<List<TaskModel>> GetWebData(int Month, int Year)
        {
            using (var ctx = new DbEntities())
            {
                var webData = await ctx.Tasks.Where(x => x.MonthId == Month && x.Year == Year && x.Type == 1).Include(x => x.SubTasks.Select(y => y.JiraTickets)).ToListAsync();

                var autoMapperConfig = new AutoMapperConfiguration().Configure();
                var iMapper = autoMapperConfig.CreateMapper();

                return iMapper.Map<List<Tasks>, List<TaskModel>>(webData);
            }
        }
        public async Task<MonthAndYearModel> GetYearAndMonths()
        {
            var response = new MonthAndYearModel();

            using (var ctx = new DbEntities())
            {
                var autoMapperConfig = new AutoMapperConfiguration().Configure();
                var iMapper = autoMapperConfig.CreateMapper();

                response.Months = iMapper.Map<List<Months>, List<MonthModel>>(await ctx.Months.ToListAsync());
                response.Years = iMapper.Map<List<Years>, List<YearModel>>(await ctx.Years.ToListAsync());
            }
            return response;
        }
        public async Task<List<HelpDeskTickets>> GetHelpDeskTickets(int Month, int Year)
        {
            List<HelpDeskTickets> list = new List<HelpDeskTickets>();

            using (var ctx = new DbEntities())
            {
                var helpTicketData = await ctx.HelpDeskTickets.Where(x => x.Month == Month && x.Year == Year).ToListAsync();

                if (helpTicketData != null)
                {
                    foreach (var item in helpTicketData)
                    {
                        HelpDeskTickets obj = new HelpDeskTickets();
                        obj.Id = item.Id;
                        obj.Category = item.Category;
                        obj.Value = item.Value;
                        list.Add(obj);
                    }
                }
                return list;
            }
        }
        public async Task<WebTrend> GetWebTrendReportData(int Month, int Year)
        {
            WebTrend list = new WebTrend();

            using (var ctx = new DbEntities())
            {              
                var StatusList = await ctx.TaskStatus.ToListAsync();

                var WebTrendSiteList = await ctx.WebTrendSiteData.Where(x => x.IsActive == true && x.Month == Month && x.Year == Year).ToListAsync();

                var webTrendSiteData = (from a in WebTrendSiteList
                                        from b in StatusList.Where(b => a.Status == b.Id)
                                        select new
                                        {
                                            a.Name,
                                            a.Description,
                                            Status = b.Description,
                                            b.Icon
                                        });

                if (webTrendSiteData != null)
                {
                    List<WebTrendSiteDataModel> SiteDataList = new List<WebTrendSiteDataModel>();
                    foreach (var item in webTrendSiteData)
                    {
                        WebTrendSiteDataModel sitedata = new WebTrendSiteDataModel();
                        sitedata.Name = item.Name;
                        sitedata.Description = item.Description;
                        sitedata.Status = item.Status;
                        sitedata.Icon = item.Icon;
                        SiteDataList.Add(sitedata);
                    }
                    list.WebTrendSiteData = SiteDataList;
                }

                var WebTrendLinkList = await ctx.WebTrendLinkData.Where(x => x.IsActive == true && x.Month == Month && x.Year == Year).ToListAsync();

                var webTrendNAEPLinkData = (from a in WebTrendLinkList
                                        from b in StatusList.Where(b => a.Status == b.Id)
                                        where a.Status == 6
                                        select new
                                        {
                                            a.Link,
                                            Status = b.Description,
                                            b.Icon
                                        });

                if (webTrendNAEPLinkData != null)
                {
                    List<WebTrendNAEPLinkDataModel> LinkDataList = new List<WebTrendNAEPLinkDataModel>();
                    foreach (var item in webTrendNAEPLinkData)
                    {
                        WebTrendNAEPLinkDataModel linkdata = new WebTrendNAEPLinkDataModel();
                        linkdata.Link = item.Link;
                        linkdata.Status = item.Status;
                        linkdata.Icon = item.Icon;
                        LinkDataList.Add(linkdata);
                    }
                    list.WebTrendNAEPLinkData = LinkDataList;
                }

                var webTrendNRCLinkData = (from a in WebTrendLinkList
                                            from b in StatusList.Where(b => a.Status == b.Id)
                                            where a.Status == 9
                                            select new
                                            {
                                                a.Link,
                                                Status = b.Description,
                                                b.Icon
                                            });

                if (webTrendNRCLinkData != null)
                {
                    List<WebTrendNRCLinkDataModel> LinkDataList = new List<WebTrendNRCLinkDataModel>();
                    foreach (var item in webTrendNAEPLinkData)
                    {
                        WebTrendNRCLinkDataModel linkdata = new WebTrendNRCLinkDataModel();
                        linkdata.Link = item.Link;
                        linkdata.Status = item.Status;
                        linkdata.Icon = item.Icon;
                        LinkDataList.Add(linkdata);
                    }
                    list.WebTrendNRCLinkData = LinkDataList;
                }

                var WbrTrendTermList = await ctx.WebTrendTermData.Where(x => x.IsActive == true && x.Month == Month && x.Year == Year).ToListAsync();

                var webTrendTermData = (from a in WbrTrendTermList
                                        from b in StatusList.Where(b => a.Status == b.Id)
                                        select new
                                        {
                                            a.Term,
                                            Status = b.Description,
                                            b.Icon
                                        });

                if (webTrendTermData != null)
                {
                    List<WebTrendTermDataModel> TermDataList = new List<WebTrendTermDataModel>();
                    foreach (var item in webTrendTermData)
                    {
                        WebTrendTermDataModel termdata = new WebTrendTermDataModel();
                        termdata.Term = item.Term;
                        termdata.Status = item.Status;
                        termdata.Icon = item.Icon;
                        TermDataList.Add(termdata);
                    }
                    list.WebTrendTermData = TermDataList;
                }

                var WebTrendResourceList = await ctx.WebTrendResourceData.Where(x => x.IsActive == true && x.Month == Month && x.Year == Year).ToListAsync();

                var webTrendResourceData = (from a in WebTrendResourceList
                                        from b in StatusList.Where(b => a.Status == b.Id)
                                        select new
                                        {
                                            a.Description,
                                            Status = b.Description,
                                            b.Icon
                                        });

                if (webTrendResourceData != null)
                {
                    List<WebTrendResourceDataModel> ResourceDataList = new List<WebTrendResourceDataModel>();
                    foreach (var item in webTrendResourceData)
                    {
                        WebTrendResourceDataModel resourcedata = new WebTrendResourceDataModel();
                        resourcedata.Description = item.Description;
                        resourcedata.Status = item.Status;
                        resourcedata.Icon = item.Icon;
                        ResourceDataList.Add(resourcedata);
                    }
                    list.WebTrendResourceData = ResourceDataList;
                }

                return list;
            }
        }
        public async Task<List<PrivateTaskModel>> GetWebPrivateData(int Month, int Year)
        {
            List<PrivateTaskModel> list = new List<PrivateTaskModel>();

            using (var ctx = new DbEntities())
            {
                var webData = await ctx.Tasks.Where(x => x.MonthId == Month && x.Year == Year && x.Type == 2 && x.IsActive == true).Include(x => x.SubTasks.Select(y => y.JiraTickets)).ToListAsync();

                if (webData != null)
                {
                    foreach (var item in webData)
                    {
                        PrivateTaskModel obj = new PrivateTaskModel();
                        obj.StatusId = item.StatusId;
                        var masttskstat = await ctx.TaskStatus.Where(x => x.Id == obj.StatusId).FirstOrDefaultAsync();
                        if (masttskstat != null)
                        {
                            obj.PrivateType = masttskstat.Description;
                            obj.Icon = masttskstat.Icon;
                        }
                        if (item.SubTasks.Count > 0)
                        {
                            List<SubTaskModel> list1 = new List<SubTaskModel>();
                            foreach (var item1 in item.SubTasks)
                            {
                                SubTaskModel obj1 = new SubTaskModel();
                                obj1.Id = item1.Id;
                                obj1.Description = item1.Description;
                                if (item1.JiraTickets.Count > 0)
                                {
                                    List<JiraTicketModel> list2 = new List<JiraTicketModel>();
                                    foreach (var item2 in item1.JiraTickets)
                                    {
                                        JiraTicketModel obj2 = new JiraTicketModel();
                                        obj2.JiraTicketId = item2.JiraTicketId;
                                        list2.Add(obj2);
                                    }
                                    obj1.JiraTickets = list2;
                                }
                                list1.Add(obj1);
                            }
                            obj.SubTasks = list1;
                        }
                        obj.Description = item.Description;
                        list.Add(obj);

                    }
                }
                return list;
            }
        }
    }
}