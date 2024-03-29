﻿using AutoMapper;
using Ws_Agenda.DTOs;
using Ws_Agenda.Models;

namespace Ws_Agenda.Services
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDto, User>();
            CreateMap<UserCreateDto, User>();
            CreateMap<ChangePasswordDto, User>(); 
            CreateMap<RecoveryPasswordDto, User>();
            CreateMap<RecoveryPassword2Dto, User>();
        }
    }
}
