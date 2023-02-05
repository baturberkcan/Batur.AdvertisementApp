﻿using AutoMapper;
using Batur.AdvertisementApp.Business.Extensions;
using Batur.AdvertisementApp.Business.Interfaces;
using Batur.AdvertisementApp.Common;
using Batur.AdvertisementApp.DataAccess.UnitOfWork;
using Batur.AdvertisementApp.Dtos;
using Batur.AdvertisementApp.Dtos.AppRoleDto;
using Batur.AdvertisementApp.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Business.Services
{
    public class AppUserManager : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private IValidator<AppUserCreateDto> _createDtoValidator;
        private IValidator<AppUserLoginDto> _loginDtoValidator;


        public AppUserManager(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow, IValidator<AppUserLoginDto> loginDtoValidator) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow; ;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }
        public async Task<IResponse<AppUserCreateDto>> CreateWithRole(AppUserCreateDto dto, int roleId)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);
                await _uow.GetRepository<AppUser>().CreateAsync(user);
                await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole { AppUser = user, AppRoleId = roleId });
                await _uow.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Success, dto);
            }
            return new Response<AppUserCreateDto>(dto, validationResult.ConvertToValidationError());
        }
        public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
        {
            var validationResult = _loginDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.Username == dto.Username && x.Password == dto.Password);
                if (user != null)
                {
                    var appUserDto = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Success, appUserDto);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound, "Kullanıcı adı veya şifre hatalı");

            }
            return new Response<AppUserListDto>(ResponseType.ValidationError, "Kullanıcı Adı veya şifresi boş olamaz");
        }
        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId)
        {
            var roles = await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if (roles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "İlgili rol bulunumadı");
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);
            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);
        }
    }
}
