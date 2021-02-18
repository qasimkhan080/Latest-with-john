using AutoMapper;
using MSRDAL.Entities;
using MSRDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSRDAL.AutoMapper
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Months, MonthModel>();
            CreateMap<Years, YearModel>();
            CreateMap<Tasks, TaskModel>();
            CreateMap<SubTasks, SubTaskModel>();
            CreateMap<JiraTickets, JiraTicketModel>();
        }
    }
    public class AutoMapperConfiguration
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            return config;
        }
    }
}
