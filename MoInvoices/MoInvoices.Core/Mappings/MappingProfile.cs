using AutoMapper;
using MoInvoices.Models;
using MoInvoices.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoInvoices.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InvoiceDTO, Invoice>()
                .ForMember(dest => dest.InvoiceID, opt => opt.MapFrom(src => src.InvoiceID))
                .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.InvoiceNumber))
                .ForMember(dest => dest.CityOfIssue, opt => opt.MapFrom(src => src.CityOfIssue))
                .ForMember(dest => dest.IsPayed, opt => opt.MapFrom(src => src.IsPayed))
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
                .ForMember(dest => dest.SellData, opt => opt.MapFrom(src => src.SellData))
                .ForMember(dest => dest.SumGrossValue, opt => opt.MapFrom(src => src.SumGrossValue))
                .ForMember(dest => dest.SumNetValue, opt => opt.MapFrom(src => src.SumNetValue))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<Invoice, InvoiceDTO>();


            CreateMap<InvoiceRowServiceDTO, InvoiceRowService>()
                .ForMember(dest => dest.InvoiceRowServiceID, opt => opt.MapFrom(src => src.InvoiceRowServiceID))
                .ForMember(dest => dest.GrossValue, opt => opt.MapFrom(src => src.GrossValue))
                .ForMember(dest => dest.JM, opt => opt.MapFrom(src => src.JM))
                .ForMember(dest => dest.NetPrice, opt => opt.MapFrom(src => src.NetPrice))
                .ForMember(dest => dest.NetWorth, opt => opt.MapFrom(src => src.NetWorth))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.ServiceName))
                .ForMember(dest => dest.VatAmount, opt => opt.MapFrom(src => src.VatAmount))
                .ForMember(dest => dest.VatRate, opt => opt.MapFrom(src => src.VatRate));

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login));

            CreateMap<ContractorDTO, Contractor>()
                .ForMember(dest => dest.ContractorID, opt => opt.MapFrom(src => src.ContractorID))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.NIP, opt => opt.MapFrom(src => src.NIP))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street));
        }
    }
}
