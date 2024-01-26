using AutoMapper;
using RH.GestionDesConges.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using RH.GestionDesConges.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using RH.GestionDesConges.Domain;

namespace RH.GestionDesConges.Application.MappingProfiles
{
	public class LeaveTypeProfile : Profile
	{
		public LeaveTypeProfile()
		{
			CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
			CreateMap<LeaveType, LeaveTypeDetailDto>();
		}
	}
}
