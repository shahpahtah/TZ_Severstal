using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using AutoMapper;
using Notes;
using Notes.ModelsDb;
namespace Services.Mappings
{
    class NoteProfile:Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteDb>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) 
                .ReverseMap();

            CreateMap<Note, NoteDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src=>src.Id)).ReverseMap();
              
        }
    }
}
